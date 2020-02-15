namespace KtpAcsMiddleware.AppService.Dto
{
    /// <summary>
    ///     新中新(Syn)身份证阅读器读取的身份证信息
    /// </summary>
    public class IdentitySynDto
    {
        /// <summary>
        ///     主键=号码
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        public string NameA { get; set; }

        /// <summary>
        ///     性别 男=1
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        ///     民族(IdentityNation)
        /// </summary>
        public int Nation { get; set; }

        /// <summary>
        ///     生日(yyyyMMdd)
        /// </summary>
        public string Born { get; set; }

        /// <summary>
        ///     地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     发证机关
        /// </summary>
        public string Police { get; set; }

        /// <summary>
        ///     激活时间(yyyyMMdd)
        /// </summary>
        public string UserLifeB { get; set; }

        /// <summary>
        ///     过期时间(yyyyMMdd)
        /// </summary>
        public string UserLifeE { get; set; }

        /// <summary>
        ///     照片流Base64str
        /// </summary>
        public string Base64Photo { get; set; }
    }
}