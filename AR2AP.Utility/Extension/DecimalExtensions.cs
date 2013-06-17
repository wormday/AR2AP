using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR2AP.Utility
{
    public static class DecimalExtensions
    {
        #region 订单号
        public static string ToShortString(this decimal number)
        {
            string str = number.ToString();
            if (str.EndsWith(".00"))
                str = str.Substring(0, str.Length - 3);
            return str;
        }
        #endregion
    }
}
