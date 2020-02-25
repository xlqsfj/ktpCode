using KtpAcsMiddleware.KtpApiService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{
    [Serializable]
    public class Workers
    {
        /// <summary>
        ///所属行名称
        /// </summary>
        public string bankName { get; set; }
        /// <summary>
        /// 所属行ID
        /// </summary>
        public int? bankId { get; set; }


        /// <summary>
        /// 插入班组ID
        /// </summary>
        public int teamId { get; set; }
        /// <summary>
        /// 查询班组ID
        /// </summary>
        public int? poId { get; set; }

        /// <summary>
        /// 班组名
        /// </summary>
        public string poName { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string popBankCard { get; set; }

        /// <summary>
        /// 身份证正面照
        /// </summary>
        public string popPic2 { get; set; }

        /// <summary>
        /// 身份证反面照
        /// </summary>
        public string popPic3 { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public string userBirthday { get; set; }

        /// <summary>
        /// 人脸采集图像
        /// </summary>
        public string userCertPic { get; set; }
        public string userCertPic64 { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string uname { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string upic { get; set; }

        /// <summary>
        ///姓名 
        /// </summary>
        public string urealname { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        public string usAddress { get; set; }

        /// <summary>
        /// 身份证到期时间
        /// </summary>
        public string usExpireTime { get; set; }

        /// <summary>
        ///民族 
        /// </summary>
        public string usNation { get; set; }

        /// <summary>
        /// 发证机构
        /// </summary>
        public string usOrg { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string usProvince { get; set; }

        /// <summary>
        /// 身份证发放时间
        /// </summary>
        public string usStartTime { get; set; }

        public int? _userId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? userId
        {
            get { return _userId; }

            set
            {
                _userId = value == 0 ? null : value;

            }

        }

        /// <summary>
        /// 性别 1男 2女
        /// </summary>
        public int usex { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string usfz { get; set; }

        /// <summary>
        /// 项目id
        /// </summary>
        public int uproid { get; set; }
        /// <summary>
        /// 认证状态:1.未认证。2已认证 ,
        /// </summary>
        public int certificationStatus { get; set; }
        /// <summary>
        /// 保存本地的文件名的识别人像
        /// </summary>
        public string localImgFileName { get; set; }
        /// <summary>
        /// 保存本地的文件名的正面身份证
        /// </summary>
        public string localImgFileName1 { get; set; }
        /// <summary>
        /// 保存本地的文件名的反面身份证
        /// </summary>
        public string localImgFileName2 { get; set; }

        public string panelIp { get; set; }
        /// <summary>
        /// 保存本地的文件名的头像
        /// </summary>
        public string localImgUpic { get; set; }

        /// <summary>
        /// 验证手机是否,验证码
        /// </summary>
        public string smsCode { get; set; }
        /// <summary>
        /// 验证黑名单是否举行添加 1、继续添加
        /// </summary>
        public int confirmAdd { get; set; }
        /// <summary>
        /// 计划离场时间
        /// </summary>
        public string planExitTime { get; set; }
        /// <summary>
        ///部门类型 1 项目部 2 班组
        /// </summary>
        public int? poType { get; set; }
        public string imgBase64 { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime updateTime { get; set; }
        /// <summary>
        /// 本地id
        /// </summary>
        public int localUserId { get; set; }
        /// <summary>
        /// 本地班组id
        /// </summary>
        public int localTeamId { get; set; }
        /// <summary>
        /// 是否同步
        /// </summary>
        public bool isSyn { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool isDel { get; set; }

        public int ktpUid { get; set; }
        public int? ktpTid { get; set; }
        public string ktpMag { get; set; }
    }





}
