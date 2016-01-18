using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xqk.Chinese;

namespace JDF.Finance.Common
{
   public class ConvertPinYin
    {
        #region 获取输入文字的数值，得到全拼和首字母方法
        /// <summary>
        /// 获取输入文字的数值，得到全拼
        /// </summary>
        /// <param name="text">获取文文字值</param>
        /// <returns>返回全拼</returns>
        public static string GetFullPinYin(string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char ch in text)
            {
                HanZi hzi = Chinese.GetHanZi(ch);
                if (hzi == null) sb.Append(ch);
                else sb.Append(hzi.PinYin);
            }

            return sb.ToString().ToLower();
        }
        /// <summary>
        /// 获取输入文字的数值，得到每个汉字首字母
        /// Damon 此方法有问题
        /// </summary>
        /// <param name="text">获取文文字数值</param>
        /// <returns>返回每个汉字首字母</returns>
        public static string GetFirstPinYin(string text)
        {
            string tempStr = "";
            foreach (char c in text)
            {
                int charindex = (int)c;
                //空格继续
                if (charindex == 32 || charindex == 8198)
                    continue;
                if (charindex >= 33 && charindex <= 126)
                {//字母和符号原样保留             
                    tempStr += c.ToString();
                }
                else
                {//累加拼音声母       
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }


        /// <summary>  
        ///取单个字符的拼音声母 
        ///summary>
        ///<param name="c">要转换的单个汉字</param>  
        ///<returns>拼音声母</returns>  
        public static string GetPYChar(string c)
        {
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1 || i == 62692 || i == 56509) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "j";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA || i == 62969) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9 || i == 62967) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA || i == 56282 || i == 61421) return "z";
            return "*";
        }

        #endregion
    }
}
