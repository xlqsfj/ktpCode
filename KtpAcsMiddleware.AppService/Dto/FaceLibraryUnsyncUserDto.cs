namespace KtpAcsMiddleware.AppService.Dto
{
    /// <summary>
    ///     人脸识别设备人脸库成员Dto
    /// </summary>
    public class FaceLibraryUnsyncUserDto
    {
        /// <summary>
        ///     主键
        /// </summary>
        public string id { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///     性别,1:女，2：男
        /// </summary>
        public int sex { get; set; }

        /// <summary>
        ///     身份证号
        /// </summary>
        public string idNumber { get; set; }

        /// <summary>
        ///     民族
        /// </summary>
        public string nation { get; set; }

        /// <summary>
        ///     地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        ///     头像
        /// </summary>
        public string avatar { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        ///     黑白名单标识 1：白名单，2：黑名单
        /// </summary>
        public int flag { get; set; }

        /// <summary>
        ///     组织Id
        /// </summary>
        public string organizationId { get; set; }

        /// <summary>
        ///     操作标识：1：新增，2：删除
        /// </summary>
        public int operation { get; set; }

        /// <summary>
        ///     人脸库Id
        /// </summary>
        public int libraryId { get; set; }

        /// <summary>
        ///     创建时间戳
        /// </summary>
        public int ctime { get; set; }

        public string groupId { get; set; }
    }
}