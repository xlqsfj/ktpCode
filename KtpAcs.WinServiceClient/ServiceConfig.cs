using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using KtpAcs.WinService;
using Microsoft.Win32;

namespace KtpAcs.WinServiceClient
{
    public class ServiceConfig
    {
        public static bool IsServiceExisted(string serviceName)

        {

            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController sc in services)

            {

                if (sc.ServiceName.ToLower() == serviceName.ToLower())

                {

                    return true;

                }

            }

            return false;

        }
        //启动服务

        public static void ServiceStart(string serviceName)

        {

            using (ServiceController control = new ServiceController(serviceName))

            {

                if (control.Status == ServiceControllerStatus.Stopped)

                {

                    control.Start();
                    ChangeServiceStartType(2, serviceName);


                }

            }

        }
        /// <summary>   
        /// 修改服务的启动项 2为自动,3为手动   
        /// </summary>   
        /// <param name="startType">启动类型</param>   
        /// <param name="serviceName">服务名</param>   
        /// <returns>是否设置成功</returns>   
        public static bool ChangeServiceStartType(int startType, string serviceName)
        {
            try
            {
                RegistryKey regist = Registry.LocalMachine;
                RegistryKey sysReg = regist.OpenSubKey("SYSTEM");
                RegistryKey currentControlSet = sysReg.OpenSubKey("CurrentControlSet");
                RegistryKey services = currentControlSet.OpenSubKey("Services");
                RegistryKey servicesName = services.OpenSubKey(serviceName, true);
                servicesName.SetValue("Start", startType);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
