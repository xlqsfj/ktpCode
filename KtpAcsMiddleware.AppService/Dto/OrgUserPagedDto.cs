using System;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.Dto
{
    public class OrgUserPagedDto
    {
        public string Id { get; set; }
        public string LoginName { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Mobile { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifiedTime { get; set; }

        /***Extension*****************************************************************************/

        public string BirthdayText
        {
            get { return FormatHelper.GetIsoDateString(Birthday); }
        }

        public string CreateTimeText
        {
            get { return FormatHelper.GetIsoDateString(CreateTime); }
        }

        public string ModifiedTimeText
        {
            get { return FormatHelper.GetIsoDateString(ModifiedTime); }
        }
    }
}