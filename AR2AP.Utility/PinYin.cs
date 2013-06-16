using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR2AP.Utility
{
    public partial class PinYin
    {

        static public void GetSpells(string cnString, out string AllSpellsString, out string SimpleSpellsString)
        {
            List<string[]> strArrayList = GetAllSpellsList(cnString);
            StringBuilder tmpAllSpells = new StringBuilder("|");
            StringBuilder tmpSimpleSpells = new StringBuilder("|");
            foreach (string[] strArray in strArrayList)
            {

                foreach (string str in strArray)
                {
                    tmpAllSpells.Append(str);
                    if (str.Length >= 1)
                        tmpSimpleSpells.Append(str.Substring(0, 1));
                }
                tmpAllSpells.Append("|");
                tmpSimpleSpells.Append("|");
            }
            AllSpellsString = tmpAllSpells.ToString();
            SimpleSpellsString = tmpSimpleSpells.ToString();
        }

        #region 获取一个汉字可能的拼音 因为存在多音字 所以返回的是个数组
        static public string[] GetCharAllSpells(char cnChar)
        {
            if (char.IsSeparator(cnChar) || char.IsPunctuation(cnChar) || char.IsWhiteSpace(cnChar))//如果字符是分隔符、标点符号等 直接返回
                return new string[] { cnChar.ToString() };
            System.Int32 CharIndex = PinyinString.IndexOf(cnChar);
            if (CharIndex < 0)
                return new string[] { "?" };
            System.Int32 CharEndIndex = PinyinString.IndexOf("|", CharIndex);
            string strPinYin = PinyinString.Substring(CharIndex + 2, CharEndIndex - CharIndex-2);
            string[] rtnArrayStr = strPinYin.Split('-');
            if (rtnArrayStr == null)
                rtnArrayStr = new string[] { cnChar.ToString() };
            return rtnArrayStr;
        }
        #endregion

        #region 获取一个字符串可能的拼音
        static public List<string[]> GetAllSpellsList(string cnString)
        {
            List<string[]> PinYinArrayList = new List<string[]>();
            foreach (char c in cnString.ToCharArray())
            {
                string[] CharPinYinArray = GetCharAllSpells(c);
                PinYinArrayList.Add(CharPinYinArray);
            }

            System.Int32[] CurrScan = new System.Int32[PinYinArrayList.Count];
            System.Int32[] MaxScan = new System.Int32[PinYinArrayList.Count];
            for (System.Int32 i = 0; i < MaxScan.Length; i++)
            {
                CurrScan[i] = 0;
                MaxScan[i] = PinYinArrayList[i].Length;//获取每一行中 拼音的数量
            }
            List<string[]> rtnList = new List<string[]>();//定义返回的值
            while (true)
            {
                string[] rtnStr = new string[cnString.Length];

                for (System.Int32 i = 0; i < PinYinArrayList.Count; i++)
                {
                    rtnStr[i] = PinYinArrayList[i][CurrScan[i]];
                }
                rtnList.Add(rtnStr);
                //===========================

                CurrScan[0]++;

                for (System.Int32 j = 0; j < PinYinArrayList.Count; j++)
                {
                    if (CurrScan[j] > MaxScan[j] - 1)
                    {
                        if (j + 1 >= PinYinArrayList.Count)
                        {
                            return rtnList;
                        }
                        CurrScan[j] = 0;
                        CurrScan[j + 1]++;
                        continue;
                    }
                    break;
                }
            }
        }
        #endregion

    }
}
