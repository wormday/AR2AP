using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AR2AP.Utility
{
    public class IDCard
    {
        public static string Per15To18(string perIDSrc)
        {
            System.Int32 iS = 0;
            //加权因子常数 
            System.Int32[] iW = new System.Int32[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            //校验码常数 
            string LastCode = "10X98765432";
            //新身份证号 
            string perIDNew;
            perIDNew = perIDSrc.Substring(0, 6);
            //填在第6位及第7位上填上‘1’，‘9’两个数字 
            perIDNew += "19";
            perIDNew += perIDSrc.Substring(6, 9);
            //进行加权求和 
            for (System.Int32 i = 0; i < 17; i++)
            {
                iS += System.Int32.Parse(perIDNew.Substring(i, 1)) * iW[i];
            }

            //取模运算，得到模值 
            System.Int32 iY = iS % 11;
            //从LastCode中取得以模为索引号的值，加到身份证的最后一位，即为新身份证号。 
            perIDNew += LastCode.Substring(iY, 1);
            return perIDNew;
        }

        public static bool CheckCidIsLegality(string cid)
        {
            cid = cid.ToLower();
            string[] aCity = new string[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };
            double iSum = 0;
            Regex rg = new Regex(@"^\d{17}(\d|x)$");
            Match mc = rg.Match(cid);
            if (!mc.Success)
                return false;
            cid = cid.Replace("x", "a");
            if (aCity[System.Int32.Parse(cid.Substring(0, 2))] == null)
                return false;
            try
            {
                DateTime.Parse(cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2));
            }
            catch
            {
                return false;
            }
            for (System.Int32 i = 17; i >= 0; i--)
            {
                iSum += (System.Math.Pow(2, i) % 11) * System.Int32.Parse(cid[17 - i].ToString(), System.Globalization.NumberStyles.HexNumber);
            }
            if (iSum % 11 != 1)
                return false;
            return true;
        }

        public static string GetSexFromIDCard(string IDCard, string maleName, string femaleName)
        {
            System.Int32 SexNumber = 0;
            if (IDCard == null || IDCard == "")
                return "";
            if (IDCard.Length == 15)
            {
                if (!System.Int32.TryParse(IDCard.Substring(14, 1), out SexNumber))
                    return "";
            }
            else if (IDCard.Length == 18)
            {
                if (!CheckCidIsLegality(IDCard))
                    return "";
                if (!System.Int32.TryParse(IDCard.Substring(16, 1), out SexNumber))
                    return "";
            }
            else
            {
                return "";
            }
            if (SexNumber % 2 == 1)
                return maleName;
            else
                return femaleName;
        }
        public static DateTime GetBirthdayFromIDCard(string IDCard)
        {
            string strBirthDay = "";
            if (IDCard.Length == 15)
            {
                strBirthDay = "19" + IDCard.Substring(6, 6);
            }
            else if (IDCard.Length == 18)
            {
                strBirthDay = IDCard.Substring(6, 8);
            }
            return DateTime.ParseExact(strBirthDay, "yyyyMMdd", null);
        }

        public static System.Int32 GetAgeByIDCard(string IDCard)
        {
            if (String.IsNullOrEmpty(IDCard))
                return -1;
            int age = 0;

            string year = "";
            if (IDCard.Trim().Length == 15)
            {
                year = "19" + IDCard.Substring(6, 2);
            }
            else if (IDCard.Trim().Length == 18)
            {
                year = IDCard.Substring(6, 4);
            }
            if (!String.IsNullOrEmpty(year))
            {
                age = DateTime.Now.Year - System.Int32.Parse(year);
            }

            return age;
        }

        public static string TestPhoneLength(string phoneStr)
        {
            string result = "";
            if (phoneStr.Substring(0, 1) == "1")
            {
                if (phoneStr.Length != 11)
                    result = "你输入的手机号位数不正确！";
            }
            else if (phoneStr.Length < 8)
            {
                result = "你输入的电话号码位数不正确";
            }
            return result;
        }
    }
}
