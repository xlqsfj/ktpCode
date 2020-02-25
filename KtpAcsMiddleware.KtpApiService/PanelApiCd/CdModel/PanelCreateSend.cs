using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel
{
  public  class PanelCreateSend: Send
    {
      
       /// <summary>
       /// 人员信息
       /// </summary>
        public Person person { get; set; }




    }
    public class Person {

        /// <summary>
        /// 
        /// </summary>
        public string age { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int  id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string idcardNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 男
        /// </summary>
        public string sex { get; set; }
    }
}
