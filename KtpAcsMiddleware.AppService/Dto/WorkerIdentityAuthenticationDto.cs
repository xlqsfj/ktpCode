namespace KtpAcsMiddleware.AppService.Dto
{
    /// <summary>
    ///     工人身份认证信息Dto(web端单独写入认证信息功能)
    /// </summary>
    public class WorkerIdentityAuthenticationDto
    {
        public string WorkerId { get; set; }
        public string IdentityId { get; set; }
        public string FacePicId { get; set; }
        public string IdentityPicId { get; set; }
        public string IdentityBackPicId { get; set; }
    }
}