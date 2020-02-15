using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.WorkerAuths;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.WorkerAuths
{
    internal class WorkerWorkingTimeService
    {
        private readonly IWorkerAuthRepository _workerAuthRepository;

        public WorkerWorkingTimeService(IWorkerAuthRepository workerAuthRepository)
        {
            _workerAuthRepository = workerAuthRepository;
        }

        /// <summary>
        ///     获取员工日工时计算结果
        /// </summary>
        public IList<WorkerDailyWorkingTimeDto> GetWorkerDailyWorkingTimes(
            string workerId, DateTime beginTime, DateTime endTime)
        {
            //时间范围验证
            if (endTime < beginTime)
            {
                throw new ArgumentOutOfRangeException(ExMessage.MustNotBeOutOfRange("TimeCycle",
                    $"beginTime={FormatHelper.GetIsoDateTimeString(beginTime)},endTime={FormatHelper.GetIsoDateTimeString(endTime)}"));
            }
            //获取需要计算的数据
            var workerAuths = _workerAuthRepository.FindCycle(workerId, beginTime, endTime);
            if (workerAuths == null)
            {
                //扩大到时间范围的前后打卡记录进行排查，检查当前范围是否刚好是没有任何打卡记录的24小时上班时间
                var previousOne = _workerAuthRepository.FindDatePreviousOne(workerId, beginTime);
                if (previousOne == null || previousOne.ClockType != (int) WorkerAuthClockType.JinZhaji)
                {
                    return null;
                }
                var latterOne = _workerAuthRepository.FindDateLatterOne(workerId, endTime);
                if (latterOne == null || latterOne.ClockType != (int) WorkerAuthClockType.ChuZhaji)
                {
                    return null;
                }
                var fullWorkerDailyWorkingTimes = new List<WorkerDailyWorkingTimeDto>();
                var workDate = beginTime;
                var curentTeamId = previousOne.TeamId;
                while (true)
                {
                    if (fullWorkerDailyWorkingTimes.Any(
                        i => i.WorkerId == workerId && i.TeamId == curentTeamId &&
                             i.WorkDate == workDate.Date))
                    {
                        continue;
                    }
                    fullWorkerDailyWorkingTimes.Add(new WorkerDailyWorkingTimeDto
                    {
                        WorkerId = workerId,
                        TeamId = curentTeamId,
                        WorkingTime = 86400, //24小时
                        WorkDate = workDate.Date
                    });
                    workDate = workDate.AddDays(1);
                    if (workDate > endTime)
                    {
                        break;
                    }
                }
                return fullWorkerDailyWorkingTimes;
            }
            //获取需要计算工时的日期
            IList<DateTime> precomputationDates = new List<DateTime>();
            foreach (var workerAuth in workerAuths)
            {
                if (precomputationDates.Contains(workerAuth.ClockTime.Date))
                {
                    continue;
                }
                precomputationDates.Add(workerAuth.ClockTime.Date);
            }
            IList<WorkerDailyWorkingTimeDto> result = new List<WorkerDailyWorkingTimeDto>();
            //遍历“获取需要计算工时的日期”，计算员工当日的工时
            foreach (var precomputationDate in precomputationDates)
            {
                //筛选出当日的打卡记录，按照打卡时间排增序排列
                var dailyWorkerAuths =
                    workerAuths.Where(i => i.ClockTime.Date == precomputationDate.Date).OrderBy(i => i.ClockTime)
                        .ToList();
                if (dailyWorkerAuths == null || dailyWorkerAuths.Count == 0)
                {
                    continue;
                }
                //当日工时-double(秒)
                double dailyWorkTime = 0;
                //整天都是上班时间的日期
                IList<DateTime> allWorkingDays = new List<DateTime>();
                //进场时间
                DateTime? inWorkTime = null;
                //出场时间
                DateTime? outWorkTime = null;
                //缺勤出场时间
                DateTime? absenceInWorkTime = null;
                //缺勤进场时间
                DateTime? absenceOutWorkTime = null;

                /******************遍历计算当日正规上下班的工时********************************/
                foreach (var dailyWorkerAuth in dailyWorkerAuths)
                {
                    //一直获取(更新)出场时间直到有进场记录出现
                    if (dailyWorkerAuth.ClockType == (int) WorkerAuthClockType.ChuZhaji)
                    {
                        if (inWorkTime == null)
                        {
                            //进场打卡记录没有时，最后一次出场作为缺勤出场时间
                            absenceOutWorkTime = dailyWorkerAuth.ClockTime;
                            continue;
                        }
                        //更新出场时间
                        outWorkTime = dailyWorkerAuth.ClockTime;
                        continue;
                    }
                    //直到有进场记录出现，结束“一直获取(更新)出场时间”
                    //如果(之前)进场时间还没出现过，则前面的最新出场时间为缺勤出场时间
                    if (inWorkTime == null)
                    {
                        inWorkTime = dailyWorkerAuth.ClockTime;
                        continue;
                    }
                    if (outWorkTime == null)
                    {
                        continue;
                    }
                    var newWorkTime = (outWorkTime.Value - inWorkTime.Value).TotalSeconds;
                    dailyWorkTime = dailyWorkTime + newWorkTime;
                    inWorkTime = dailyWorkerAuth.ClockTime; //更新进场时间，进入下一轮的进场工时获取
                    outWorkTime = null;
                }
                if (inWorkTime != null)
                {
                    if (outWorkTime != null)
                    {
                        //最后一次计算
                        var newWorkTime = (outWorkTime.Value - inWorkTime.Value).TotalSeconds;
                        dailyWorkTime = dailyWorkTime + newWorkTime;
                    }
                    else
                    {
                        //进场打卡记录后找不到对应的出场记录时，标记为缺勤进场记录
                        absenceInWorkTime = inWorkTime;
                    }
                }
                /******************对于当天出现缺勤出场的工时补充******************/
                if (absenceOutWorkTime != null)
                {
                    var previousOne = workerAuths.OrderByDescending(i => i.ClockTime)
                        .FirstOrDefault(t => t.WorkerId == workerId && t.ClockTime < precomputationDate.Date);
                    if (previousOne == null)
                    {
                        previousOne = _workerAuthRepository.FindDatePreviousOne(workerId, precomputationDate);
                    }
                    if (previousOne != null && previousOne.ClockType == (int) WorkerAuthClockType.JinZhaji)
                    {
                        //缺勤出场的打卡记录对应的上一条打卡记录为进场打卡时，当天的缺勤出场工时按通宵上班算
                        //通宵上班，上班时间切割为两天，按日期补充缺勤的工时
                        var newWorkTime = (absenceOutWorkTime.Value - precomputationDate.Date).TotalSeconds;
                        dailyWorkTime = dailyWorkTime + newWorkTime;

                        //持续几天上班处理:记录为每天上班24小时；向前计算
                        var workingDays = (absenceOutWorkTime.Value.Date.AddDays(-1) - previousOne.ClockTime.Date).Days;
                        if (workingDays > 0)
                        {
                            for (var i = 1; i < workingDays; i++)
                            {
                                var newAllWorkingDay = absenceOutWorkTime.Value.Date.AddDays(-i);
                                allWorkingDays.Add(newAllWorkingDay);
                            }
                        }
                    }
                }
                /******************对于当天出现缺勤进场的工时补充******************/
                if (absenceInWorkTime != null)
                {
                    var latterOne = workerAuths.OrderBy(i => i.ClockTime)
                        .FirstOrDefault(
                            t => t.WorkerId == workerId && t.ClockTime >= precomputationDate.Date.AddDays(1));
                    if (latterOne == null)
                    {
                        latterOne = _workerAuthRepository.FindDateLatterOne(workerId, precomputationDate);
                    }
                    if (latterOne != null && latterOne.ClockType == (int) WorkerAuthClockType.ChuZhaji)
                    {
                        //缺勤进场的打卡记录对应的下一条打卡记录为出场打卡时，当天的缺勤进场工时按通宵上班算
                        //通宵上班，上班时间切割为两天，按日期补充缺勤的工时
                        var newWorkTime = (precomputationDate.Date.AddDays(1) - absenceInWorkTime.Value).TotalSeconds;
                        dailyWorkTime = dailyWorkTime + newWorkTime;
                        //持续几天上班处理:记录为每天上班24小时；向后计算
                        var workingDays = (latterOne.ClockTime.Date - absenceInWorkTime.Value.Date.AddDays(1)).Days;
                        if (workingDays > 0)
                        {
                            for (var i = 1; i < workingDays; i++)
                            {
                                var newAllWorkingDay = absenceInWorkTime.Value.Date.AddDays(i);
                                allWorkingDays.Add(newAllWorkingDay);
                            }
                        }
                    }
                }
                /******************结算并写入返回值******************************************************/
                var curentTeamId = dailyWorkerAuths[0].TeamId;
                //添加当日工时到结果中
                var workerDailyWorkingTimeDto = new WorkerDailyWorkingTimeDto
                {
                    WorkerId = workerId,
                    TeamId = curentTeamId,
                    WorkingTime = (decimal) dailyWorkTime,
                    WorkDate = precomputationDate.Date
                };
                result.Add(workerDailyWorkingTimeDto);
                //添加24小时通过日期到结果中
                if (allWorkingDays.Count > 0)
                {
                    foreach (var allWorkingDay in allWorkingDays)
                    {
                        if (result.Any(i => i.WorkerId == workerId && i.TeamId == curentTeamId &&
                                            i.WorkDate == allWorkingDay.Date))
                        {
                            continue;
                        }
                        result.Add(new WorkerDailyWorkingTimeDto
                        {
                            WorkerId = workerId,
                            TeamId = curentTeamId,
                            WorkingTime = 86400, //24小时
                            WorkDate = allWorkingDay.Date
                        });
                    }
                }
            }
            //返回结果做时间范围过滤
            result = result.Where(i => i.WorkDate >= beginTime && i.WorkDate <= endTime).ToList();
            return result;
        }
    }
}