using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage
{
    public class PanelResult
    {
        /// <summary>
        /// 闸机返回的值
        /// </summary>
        public Response Response { get; set; }


    }
    public class PanelDeleteResult
    {
        /// <summary>
        /// 闸机返回的值
        /// </summary>

        public ResponseDelete Response { get; set; }

    }
    public   class PResult
    {
        public  PanelResult PanelResult;
        public  PanelDeleteResult ErrorPanelResult;
    }

}
