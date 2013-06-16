using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR2AP.Utility
{
    public class Common
    {
        #region 生成随机数
        private static char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random(DateTime.Now.Hour * DateTime.Now.Minute * DateTime.Now.Second * DateTime.Today.Day);
            for (int i = 0; i < Length; i++)
                newRandom.Append(constant[rd.Next(10)]);
            return newRandom.ToString();
        }
        #endregion

        #region MD5
        public static string MD5(string str)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] b = Encoding.UTF8.GetBytes(str);
            byte[] md5b = md5.ComputeHash(b);
            md5.Clear();
            StringBuilder sb = new StringBuilder();
            foreach (var item in md5b)
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString(); 
        }
        #endregion
    }
}
