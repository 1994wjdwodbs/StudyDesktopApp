using System;
using System.Collections.Generic;
using System.Net;

namespace BookRentalShopApp.Helper
{
    public static class Common
    {
        public static string ConnString = "Data Source=127.0.0.1;" +
                                          "Initial Catalog=bookrentalshop;" +
                                          "Persist Security Info=True;" +
                                          "User ID=sa; Password=mssql_p@ssw0rd!";

        public static string LoginUserId = string.Empty;

        // 아이피 주소 받아오는 메서드
        internal static string GetLocalIp()
        {
            string localIP = string.Empty;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }

            return localIP;
        }
        // SQL Injection 기초적인 처리 (Secure Coding)
        internal static string ReplaceCmdText(string strSource)
        {
            var result = strSource.Replace("'", "＇"); // 'ㄱ' + 한자3번(관련없는 따옴표)

            return (((strSource.Replace("'", "＇")).Replace("--", "")).Replace(";", ""));
        }
    }

}
