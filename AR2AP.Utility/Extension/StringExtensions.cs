using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AR2AP.Utility
{
    public static class StringExtensions
    {
        #region 是否包含数值
        public static bool IncludeDigit(this string str)
        {
            foreach (char c in str)
            {
                if ("0123456789".IndexOf(c) >= 0)
                    return true;
            }
            return false;
        }
        #endregion

        #region 是否纯数字
        private static Regex regexIsDigit = new Regex(@"^\d+$");
        public static bool IsDigit(this string str)
        {
            return regexIsDigit.IsMatch(str);
        }
        #endregion

        #region 是否是空白或者Null

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        #endregion

        #region 字符转换为日期
        public static DateTime ToDate(this string str)
        {
            if (str.Length != 4)
                throw new ArgumentException("str");

            int currYear = DateTime.Now.Year;
            DateTime d1 = DateTime.ParseExact(currYear + str, "yyyyMMdd", null);
            DateTime d2 = DateTime.ParseExact((currYear + 1).ToString() + str, "yyyyMMdd", null);
            DateTime d3 = DateTime.ParseExact((currYear - 1).ToString() + str, "yyyyMMdd", null);
            double sp1 = Math.Abs((DateTime.Now - d1).TotalDays);
            double sp2 = Math.Abs((DateTime.Now - d2).TotalDays);
            double sp3 = Math.Abs((DateTime.Now - d3).TotalDays);

            if (sp1 < sp2)
            {
                d2 = d1;
                sp2 = sp1;
            }
            else
            {
                d1 = d2;
                sp1 = sp2;
            }
            if (sp2 < sp3)
            {
                sp3 = sp2;
                d3 = d2;
            }
            else
            {
                sp2 = sp3;
                d2 = d3;
            }
            return d3;
        }
        #endregion

        #region 将逗号分隔的数字转化为数字数组
        public static int[] SplitToIntArray(this string str)
        {
            var strArray = str.Split(new char[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries);
            Int32[] rtnValue = new Int32[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                rtnValue[i] = int.Parse(strArray[i]);
            }
            return rtnValue;
        }
        #endregion

        #region 格式化电话号码
        public static string FormatPhoneNumber(this string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim();
            if (phoneNumber.Length == 12 && phoneNumber.Substring(0, 2) == "01")//删除手机号码的前导0
            {
                return phoneNumber.Substring(1);
            }
            return phoneNumber;
        }
        #endregion

        #region 清除字符串的空白（NULL也处理）
        public static string TrimString(this string str)
        {
            if (str != null)
                str = str.Trim();
            return str;
        }
        #endregion

    }
}
