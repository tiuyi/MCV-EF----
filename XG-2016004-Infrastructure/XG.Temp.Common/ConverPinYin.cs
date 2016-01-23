using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xqk.Chinese;

namespace XG.Temp.Common
{
   public class ConverPinYin
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

            return sb.ToString();
        }
        /// <summary>
        /// 获取输入文字的数值，得到每个汉字首字母
        /// </summary>
        /// <param name="text">获取文文字数值</param>
        /// <returns>返回每个汉字首字母</returns>
        public static string GetFirstPinYin(string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char ch in text)
            {
                HanZi hz = Chinese.GetHanZi(ch);
                if (hz == null) sb.Append(ch);
                else sb.Append(hz.FirstPinYin);
            }

            return sb.ToString();
        }
        #endregion
    }
}
