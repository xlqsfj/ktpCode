using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{
    /// <summary>
    /// 查询班组信息
    /// </summary>
    public class WorkerTeamInfo
    {
        public Team GetTeamIdInfo(int id)
        {

            List<Team> teams = GetTeamListInfo();
            return teams.FirstOrDefault(a => a.sectionId == id);
        }

        public List<Team> GetTeamListInfo()
        {
            List<Team> list = new List<Team>();
            try
            {
                IMulePusher pusher = new TeamGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId } };
                PushSummary push = pusher.Push();

                if (push.Success)
                {
                    TeamResult r = push.ResponseData;
                    list = r.data;
                }
                else
                {
                    throw new PreValidationException(push.Message);

                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}
