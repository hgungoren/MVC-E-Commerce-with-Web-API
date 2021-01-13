using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace COMMON
{
    public static class GetIpAddress
    {
        public static string GetHostName()
        {
            string ip = null;
            var localIpAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var item in localIpAddresses)
            {
                if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = item.ToString();
                }
            }

            return ip;
        }
    }
}
