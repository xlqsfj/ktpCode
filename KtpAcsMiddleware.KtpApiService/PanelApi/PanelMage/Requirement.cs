using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApi
{
    /// <summary>
    /// 闸机返回的类型
    /// </summary>
    public enum Requirement
    {
        
        /// <summary>
        /// 表示根据返回的内容中的某个值来确定这个字节是否存在，并不是指某产品有而其他产品没有
        /// </summary>
        C,
        /// <summary>
        /// 表示这个字段是可选的，客户端解析时如果没有这个字段不能判断为错误;
        /// </summary>
        o,
        /// <summary>
        /// 表示无论什么情况下这个节点都存在，不存在则客户端可以做为错误处理;
        /// </summary>
        m

    }
}
