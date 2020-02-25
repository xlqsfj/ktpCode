using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService
{
    /// <summary>
    /// mule数据推送器接口
    /// </summary>
    public interface IMulePusher
    {
        /// <summary>
        /// 发起数据推送
        /// </summary>
        /// <returns></returns>
        PushSummary Push();
        /// <summary>
        /// 发起数据表单推送
        /// </summary>
        /// <returns></returns>
        PushSummary PushForm();

        ///// <summary>
        ///// 推送某一张单据
        ///// </summary>
        ///// <param name="billID"></param>
        ///// <returns></returns>
        //PushSummary Push(int billID);

        /// <summary>
        /// 单次推送数据最多包含的数据条目数。返回0表示不限制大小
        /// </summary>
        int MaxPackageSize { get; }

  

      
    }
    /// <summary>
    /// 约定返回结果可提供错误信息的接口
    /// </summary>
    public interface IReceiveMessage
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        string Message { get; set; }
    }
}