using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers.Model
{
    public class TeamWorkType
    {


        public int? Value { get; set; }
        public string Name { get; set; }


        public List<TeamWorkType> GetTeamWork()
        {

            List<TeamWorkType> newTeamWorkTypes = new List<TeamWorkType>();
            newTeamWorkTypes.Add(new TeamWorkType { Value = 19, Name = "木工" });
            newTeamWorkTypes.Add(new TeamWorkType { Value = 20, Name = "铁工" });
            newTeamWorkTypes.Add(new TeamWorkType { Value = 21, Name = "混泥土" });
            newTeamWorkTypes.Add(new TeamWorkType { Value = 22, Name = "外架" });
            newTeamWorkTypes.Add(new TeamWorkType { Value = 23, Name = "粗装修" });
            newTeamWorkTypes.Add(new TeamWorkType { Value = 24, Name = "其他" });

            return newTeamWorkTypes;
        }

    }
}
