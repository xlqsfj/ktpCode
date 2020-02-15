using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Base;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.WorkerAuths;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Search.Sort;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.WorkerAuths
{
    internal class WorkerAuthService : IWorkerAuthService
    {
        private readonly IFileMapRepository _fileMapRepository;
        private readonly IWorkerAuthRepository _repository;
        private readonly WorkerWorkingTimeService _workerWorkingTimeService;

        public WorkerAuthService(
            IWorkerAuthRepository repository,
            IFileMapRepository fileMapRepository,
            WorkerWorkingTimeService workerWorkingTimeService)
        {
            _repository = repository;
            _fileMapRepository = fileMapRepository;
            _workerWorkingTimeService = workerWorkingTimeService;
        }

        public void CollectionWorkerAuths()
        {
            var newWorkerAuths = _repository.FindTopOneThousandNews();
            if (newWorkerAuths == null)
            {
                return;
            }
            var erros = string.Empty;
            foreach (var newDto in newWorkerAuths)
            {
                try
                {
                    var clockPicId = SaveWorkerAuthClockPic(newDto.ClockPic);
                    var newWorkerAuth = new WorkerAuth
                    {
                        Id = ConfigHelper.NewGuid,
                        WorkerId = newDto.WorkerId,
                        TeamId = newDto.TeamId,
                        TeamName = newDto.TeamName,
                        ClockType = newDto.ClockType,
                        ClockTime = newDto.ClockTime,
                        SimilarDegree = newDto.SimilarDegree,
                        IsPass = newDto.IsPass,
                        ClockPicId = clockPicId,
                        AuthId = newDto.AuthId,
                        ClientCode = newDto.ClientCode
                    };
                    _repository.Add(newWorkerAuth);
                }
                catch (Exception ex)
                {
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},AuthId={newDto.AuthId}|";
                }
            }
            //清理原始考勤图片(Base64String to fileId)
            _repository.ClearAuthClockPics();
            //采集的数量为1000，代表还有需要采集的数据，通过递归的方式每次采集一千条数据
            if (newWorkerAuths.Count == 1000)
            {
                CollectionWorkerAuths();
            }
        }

        public PagedResult<WorkerAuthPagedDto> GetPaged(
            int pageIndex, int pageSize, string keywords, string teamId, DateTime? authDate)
        {
            var searchCriteria = new SearchCriteria<WorkerAuth>();
            if (!string.IsNullOrEmpty(teamId))
            {
                searchCriteria.AddFilterCriteria(t => t.Worker.TeamId == teamId);
            }
            if (authDate != null)
            {
                searchCriteria.AddFilterCriteria(
                    t => t.ClockTime >= authDate.Value.Date && t.ClockTime < authDate.Value.Date.AddDays(1));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                searchCriteria.AddFilterCriteria(
                    t => t.Worker.Name.Contains(keywords) || t.Worker.WorkerIdentity.Code.Contains(keywords)
                         || t.ClientCode.Contains(keywords));
            }

            searchCriteria.AddSortCriteria(
                new ExpressionSortCriteria<WorkerAuth, DateTime>(s => s.ClockTime, SortDirection.Descending));
            searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
            var pagedResult = _repository.FindPaged(searchCriteria);
            IList<WorkerAuthPagedDto> workerAuths = pagedResult.Entities.Select(t => new WorkerAuthPagedDto
            {
                Id = t.Id,
                WorkerId = t.WorkerId,
                WorkerName = t.Worker.Name,
                IdentityCode = t.Worker.WorkerIdentity.Code,
                ClockType = t.ClockType,
                ClockTime = t.ClockTime,
                SimilarDegree = t.SimilarDegree,
                ClientCode = t.ClientCode,
                TeamName = t.Worker.Team.Name
            }).ToList();
            return new PagedResult<WorkerAuthPagedDto>(pagedResult.Count, workerAuths);
        }

        public IList<WorkerAuth> GetCycleList(string workerId, DateTime? beginTime, DateTime? endTime)
        {
            //若当前工人无打卡记录，直接返回null
            var lastClock = _repository.FindLast(workerId);
            if (lastClock == null)
            {
                return null;
            }
            DateTime endTimeVal;
            if (endTime != null)
            {
                endTimeVal = endTime.Value;
            }
            else
            {
                endTimeVal = DateTime.Now;
            }
            //如果开始时间为null，则获取最后5天的打卡记录
            if (beginTime == null)
            {
                endTimeVal = lastClock.ClockTime;
                beginTime = lastClock.ClockTime.Date.AddDays(-4);
            }
            //时间范围验证
            if (endTimeVal < beginTime)
            {
                throw new ArgumentOutOfRangeException(ExMessage.MustNotBeOutOfRange("TimeCycle",
                    $"beginTime={FormatHelper.GetIsoDateTimeString(beginTime)},endTime={FormatHelper.GetIsoDateTimeString(endTimeVal)}"));
            }

            var workerAuths = _repository.FindCycle(workerId, beginTime.Value, endTimeVal);
            if (workerAuths == null || workerAuths.Count == 0)
            {
                return null;
            }
            return workerAuths.OrderByDescending(i => i.ClockTime).ToList();
        }

        public IList<WorkerDailyWorkingTimeDto> GetWorkerDailyWorkingTimes(
            string workerId, DateTime beginTime, DateTime? endTime)
        {
            if (string.IsNullOrEmpty(workerId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(workerId)));
            }
            if (endTime == null)
            {
                endTime = DateTime.Now;
            }

            ////测试数据
            //var fullWorkerDailyWorkingTimes = new List<WorkerDailyWorkingTimeDto>();
            //var workDate = beginTime;
            //var rd = new Random();
            //while (true)
            //{
            //    if (fullWorkerDailyWorkingTimes.Any(
            //        i => i.WorkerId == workerId &&i.WorkDate == workDate.Date))
            //    {
            //        continue;
            //    }
            //    fullWorkerDailyWorkingTimes.Add(new WorkerDailyWorkingTimeDto
            //    {
            //        WorkerId = workerId,
            //        TeamId = string.Empty,
            //        WorkingTime = rd.Next(0, 86400),
            //        WorkDate = workDate.Date
            //    });
            //    workDate = workDate.AddDays(1);
            //    if (workDate > endTime)
            //    {
            //        break;
            //    }
            //}
            //return fullWorkerDailyWorkingTimes;

            return _workerWorkingTimeService.GetWorkerDailyWorkingTimes(workerId, beginTime, endTime.Value);
        }

        private string SaveWorkerAuthClockPic(string clockPic)
        {
            var data = Convert.FromBase64String(clockPic);
            var newFileMap = new FileMap
            {
                FileName = $"{ConfigHelper.NewTimeGuid}.jpg",
                Length = data.Length
            };
            var fileName = ConfigHelper.CustomFilesDir + newFileMap.FileName;
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                fileStream.Write(data, 0, data.Length);
            }
            newFileMap.Id = ConfigHelper.NewGuid;
            _fileMapRepository.Add(newFileMap);
            return newFileMap.Id;
        }
    }
}