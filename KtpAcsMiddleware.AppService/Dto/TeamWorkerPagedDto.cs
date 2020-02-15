using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Serialization;

namespace KtpAcsMiddleware.AppService.Dto
{
    public class TeamWorkerPagedDto
    {
        /// <summary>
        ///     主键ID
        /// </summary>
        public string Id { get; set; }

        public string WorkerName { get; set; }
        public string IdentityCode { get; set; }
        public int Sex { get; set; }
        public string Mobile { get; set; }
        public string Nation { get; set; }
        public string AddressNow { get; set; }
        public string TeamName { get; set; }

        /// <summary>
        ///     Do not show. For AuthenticationState
        /// </summary>
        public string FacePicId { get; set; }

        /// <summary>
        ///     Do not show. For AuthenticationState
        /// </summary>
        public string IdentityPicId { get; set; }

        /// <summary>
        ///     Do not show. For AuthenticationState
        /// </summary>
        public string IdentityBackPicId { get; set; }

        /// <summary>
        ///     Do not show
        /// </summary>
        public string TeamId { get; set; }

        public WorkerAuthenticationState AuthenticationState
        {
            get
            {
                if (string.IsNullOrEmpty(FacePicId))
                {
                    return WorkerAuthenticationState.WaitFor;
                }
                if (string.IsNullOrEmpty(IdentityPicId))
                {
                    return WorkerAuthenticationState.WaitFor;
                }
                if (string.IsNullOrEmpty(IdentityBackPicId))
                {
                    return WorkerAuthenticationState.WaitFor;
                }
                return WorkerAuthenticationState.Already;
            }
        }

        public string AuthenticationStateText
        {
            get { return AuthenticationState.ToEnumText(); }
        }

        public string SexText
        {
            get { return ((WorkerSex) Sex).ToEnumText(); }
        }
    }
}