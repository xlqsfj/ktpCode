using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage
{
   public  enum FaceRecoState
    {
        //处理结果状态码
        //0：成功;
        //1：通用执行失败;
        //2：初始化检测失败;
        //3：人脸检测失败;
        //4：图片未检测到人脸;
        //5：jpeg 照片解码失败;
        //6：人脸图片质量分数不满足;
        //7：图片缩放失败;
        //8：未启用智能;
        //9：图片不存在或过大/过小; FaceNum 为0时，此字段可选
        /// <summary>
        ///人脸识别返回 1: 成功 Succeed
        /// </summary>
        [Description("成功")] Succeed= 0,
        /// <summary>
        ///人脸识别返回 1：通用执行失败;
        /// </summary>
        [Description("通用执行失败")] CurrencyFail = 1,
        /// <summary>
        ///人脸识别返回2：初始化检测失败;
        /// </summary>
        [Description("初始化检测失败")] InitFail = 2,
        /// <summary>
        ///人脸识别返回 3：人脸检测失败;
        /// </summary>
        [Description("人脸检测失败")] FaceFail = 3,
        /// <summary>
        ///人脸识别返回 4：图片未检测到人脸;
        /// </summary>
        [Description("图片未检测到人脸")] FaceNo = 4,
        /// <summary>
        ///人脸识别返回 5：jpeg 照片解码失败;
        /// </summary>
        [Description("jpeg 照片解码失败")] DeCodeFail = 5,
        /// <summary>
        ///人脸识别返回  6：人脸图片质量分数不满足;
        /// </summary>
        [Description("人脸图片质量分数不满足")] FaceQcFail = 6,
        /// <summary>
        ///人脸识别返回 7：图片缩放失败;
        /// </summary>
        [Description("图片缩放失败")] ImgFail =7,
        /// <summary>
        ///人脸识别返回 8：未启用智能
        /// </summary>
        [Description("未启用智能")] NOState = 8,
        /// <summary>
        ///人脸识别返回 9:图片不存在或过大/过小; FaceNum 为0时，此字段可选
        /// </summary>
        [Description("图片不存在或过大/过小")] ImgNOExit = 9,
    }
}
