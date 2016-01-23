using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Globalization;
using System.Xml.Serialization;
using System.Xml;
using System.Text;

namespace XG.Temp.Common
{
    /// <summary>
    /// Summary description for Misc
    /// </summary>
    public partial class Misc
    {

        public Misc()
        {
            //
            // TODO: Add constructor logic here
            //        
        }



        public static DateTime ConvertToDateTime(string date)
        {
            DateTime newValue = DateTime.Now;

            try
            {
                newValue = Convert.ToDateTime(date);
            }
            catch
            {
            }

            return newValue;
        }

        public static int GetFormValueAsInt(string param)
        {
            int value = 0;

            try
            {
                value = Convert.ToInt32(HttpContext.Current.Request.Form[param]);
            }
            catch
            {
            }

            return value;
        }

        public static DateTime? ConvertToDateTime(string date, DateTime? returnValue)
        {
            DateTime? newValue = returnValue;

            try
            {
                newValue = Convert.ToDateTime(date);
            }
            catch
            {
            }

            return newValue;
        }


        public static string ConvertToShortDateTime(object date, string format)
        {
            string newValue = "";

            try
            {
                if (date != null)
                    newValue = Convert.ToDateTime(date).ToString(format);
            }
            catch
            {
            }

            return newValue;
        }




        public static string[] SplitString(string text, char delimiter)
        {
            string[] items = text.Split(delimiter);
            return items;
        }

        public static string CapitaliseFirstLetter(string text)
        {
            try
            {
                if (text.Length > 0)
                {
                    text = text[0].ToString().ToUpper() + text.Substring(1);
                }
            }
            catch { }

            return text;
        }

        public static string LowerFirstLetter(string text)
        {
            if (text.Length > 0)
            {
                text = text[0].ToString().ToLower() + text.Substring(1);
            }

            return text;
        }

        public static void WriteToFile(string strPath, ref byte[] Buffer)
        {
            // Create a file
            FileStream newFile = new FileStream(strPath, FileMode.Create);

            // Write data to the file
            newFile.Write(Buffer, 0, Buffer.Length);

            // Close file
            newFile.Close();
        }


        public static string NewGUID()
        {
            string newGUID;

            newGUID = Guid.NewGuid().ToString();

            return newGUID;
        }

        public static decimal ConvertToDecimal(string value)
        {
            decimal newValue = 0;
            value = value.Replace("£", "");

            Decimal.TryParse(value, out newValue);

            return newValue;
        }

        public static decimal ConvertToDecimal(double value)
        {
            decimal newValue = 0;

            Decimal.TryParse(value.ToString(), out newValue);

            return newValue;
        }

        public static double ConvertToDouble(string value)
        {
            double newValue = 0;

            Double.TryParse(value.ToString(), out newValue);

            return newValue;
        }

        public static int ConvertToInt(object value)
        {
            int newValue = 0;
            try
            {
                newValue = Convert.ToInt32(value);
            }
            catch { }

            return newValue;
        }

        public static int ConvertToInt(string value)
        {
            int newValue = 0;

            Int32.TryParse(value, out newValue);

            return newValue;
        }

        public static string ClearHtml(string text)
        {
            string Pattern = "(<[^>]*>)";

            text = text.Replace("&nbsp;", " ");
            text = text.Replace("&quot;", "");
            text = Regex.Replace(text, Pattern, "");
            Pattern = "[<]";

            text = Regex.Replace(text, Pattern, "");
            Pattern = "[>]";

            text = Regex.Replace(text, Pattern, "");
            Pattern = "[--]";

            text = Regex.Replace(text, "'", "''");
            text = Regex.Replace(text, ";", "");
            text = Regex.Replace(text, "\"", "");

            return text;

        }
        /// <summary>
        /// 获取Form或者Query值
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string GetRequstValue(string param)
        {
            string value = string.Empty;

            try
            {
                value = HttpContext.Current.Request[param].ToString();
            }
            catch
            {
            }

            return value;
        }

        public static string ClearFilename(object filename)
        {
            string file = "";
            if (filename != null)
            {
                file = Convert.ToString(filename);

                file = file.Replace("&", "");
                file = file.Replace("|", "");
                file = file.Replace("'", "");
                file = file.Replace("\"", "");
                file = file.Replace("%", "");
                file = file.Replace("?", "");
                file = file.Replace("@", "");
                file = file.Replace("/", "");
                file = file.Replace(":", "");
                file = file.Replace(".", "");
                file = file.Replace("-", "");
                file = file.Replace("*", "");
                file = file.Replace("\\", "");
                file = file.Replace(" ", "_");
                file = file.Replace("#", "");
            }

            return file;
        }



        public static string GetFormValue(string param)
        {
            string value = string.Empty;

            try
            {
                value = HttpContext.Current.Request.Form[param].ToString();
            }
            catch
            {
            }

            return value;
        }

        /// <summary>
        /// 将Form或者Query值转换成decimal
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>

        public static int GetRequstValueAsInt(string param)
        {
            int value = 0;

            try
            {
                value = Convert.ToInt32(HttpContext.Current.Request[param]);
            }
            catch
            {
            }

            return value;
        }

        /// <summary>
        /// 将Form或者Query值转换成decimal
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static decimal GetRequstValueAsDecimal(string param)
        {
            decimal number = 0;
            Decimal.TryParse(HttpContext.Current.Request[param], out number);
            return number;
        }

        /// <summary>
        /// 将Form或者Query值转换成DateTime,如果无法转换将返回最小时间
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DateTime GetRequstValueAsDateTime(string param)
        {
            DateTime date = DateTime.MinValue;
            DateTime.TryParse(HttpContext.Current.Request[param], out date);

            return date;
        }


        static public void SetMetaValues(System.Web.UI.HtmlControls.HtmlHead head, string name, string content)
        {
            HtmlMeta metaValue = null;

            metaValue = new HtmlMeta();
            metaValue.Attributes.Add("name", name);
            metaValue.Attributes.Add("content", content);
            head.Controls.Add(metaValue);
        }

        public static string MaxCharacters(string text, int characters)
        {
            string value = text;

            if (value.Length > characters)
                value = value.Substring(0, characters);

            return value;
        }



        public static string MaxCharacters(object text, int characters)
        {
            if (text != null)
            {
                string value = text.ToString();

                if (value.Length > characters)
                    value = value.Substring(0, characters);


                return value;
            }
            else
            {
                return "";
            }
        }

        public static string MaxCharacters(object text, int characters, string append)
        {
            if (text != null)
            {
                string value = text.ToString();

                if (value.Length > characters)
                    value = value.Substring(0, characters) + append;

                return value;
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="fileUploadControl">Upload Control</param>
        /// <param name="uploadPath">Relative path to save file to, with trailing /</param>
        /// <param name="allowedExtensions">exensions allowed, lowercase (.jpg .gif)</param>
        /// <returns>Filename is returned, without the path</returns>
        public static string UploadFile(FileUpload fileUploadControl, string uploadPath, string allowedExtensions)
        {

            string ShortData = Misc.ConvertToShortDateTime(System.DateTime.Now, "yyyy-MM-dd");
            string savePath = HttpContext.Current.Server.MapPath(uploadPath + "//" + ShortData + "//");
            string newFileName = "";

            if (fileUploadControl.HasFile)
            {
                string fileName = HttpContext.Current.Server.HtmlEncode(fileUploadControl.FileName);
                string extension = System.IO.Path.GetExtension(fileName);

                if (allowedExtensions.Contains(extension.ToLower()))
                {
                    newFileName = Misc.MaxCharacters(System.Guid.NewGuid().ToString(), 5) + "-" + Misc.MaxCharacters(fileUploadControl.FileName.Replace(extension, ""), 20) + extension;
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }
                    savePath += newFileName;

                    fileUploadControl.SaveAs(savePath);
                }
                else
                {
                    newFileName = "";
                }
            }

            return ShortData + "/" + newFileName;
        }





        public static void Serialize<T>(T xmlObject, string pathName, Encoding encoding)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(HttpContext.Current.Server.MapPath(pathName), encoding);
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlSerializer.Serialize(xmlTextWriter, xmlObject);
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();
        }

        /// <summary>
        /// 获取Length位随机数(不重复)
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GetRandom(int Length)
        {
            string allchars = System.Guid.NewGuid().ToString().Replace("-", "");
            StringBuilder res = new StringBuilder(10);
            Random rand = new Random();
            int length1 = Length / 2;
            for (int i = 0; i < length1; i++)
            {
                res.Append(allchars[rand.Next(10)]);
            }
            int length2 = Length - length1;
            for (int i = 0; i < length2; i++)
            {
                res.Append(allchars[rand.Next(10, allchars.Length)]);
            }
            return res.ToString().ToUpper();
        }


        /// <summary>
        /// 获取字符串的字节长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetRealLength(string str)
        {
            byte[] arr = System.Text.Encoding.Default.GetBytes(str);

            return arr.Length;
        }

        public static DataTable LoadXML2(string path)
        {
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                //读取XML到DataTable
                ds.ReadXml(GetFileFullPath(path));
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        #region GetXmlFullPath
        ///
        /// 返回完整路径
        ///
        /// Xml的路径
        ///
        public static string GetFileFullPath(string strPath)
        {
            //返回完整路径
            return System.Web.HttpContext.Current.Server.MapPath(strPath);

        }
        #endregion


        /// <summary>  
        /// 汉字转拼音首字母缩写  
        /// </summary>
        /// <param name="str">要转换的汉字字符串</param>  
        /// <returns>拼音缩写</returns>  
        public static string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
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

        /// <summary>
        /// 获取排序时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetRankTime()
        {
            DateTime endTime = DateTime.Now;
            DateTime beginTime = Convert.ToDateTime("2014-01-01");
            TimeSpan TS = new TimeSpan();
            TS = beginTime - endTime;
            return beginTime.AddMilliseconds(TS.TotalMilliseconds);
        }

        /// <summary>
        /// 获取string的前几位非数字的字母
        /// </summary>
        /// <returns></returns>
        public static string GetStringPreChar(string str)
        {
            string PreChar = "";
            for (int i = 0; i < str.Length; i++)
            {
                //如果是字母
                if (char.IsLetter(str[i]))
                {
                    PreChar += str[i];
                }
                else {

                    break;
                }

            }
            return PreChar;
        }


        /// <summary>
        /// 通过post请求获取数据
        /// </summary>
        /// <param name="url">将要post的地址</param>
        /// <param name="postString">将要传递的参数eg:adminuser=1&pasword=1</param>
        /// <returns></returns>
        public static string SendPostRequest(string url, string postString)
        {
            byte[] postData = Encoding.UTF8.GetBytes(postString);
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            client.Headers.Add("ContentLength", postData.Length.ToString());
            byte[] responseData = client.UploadData(url, "POST", postData);
            return Encoding.UTF8.GetString(responseData);
        }

        #region 添加单引号
        /// <summary>
        /// 添加单引号
        /// </summary>
        /// <param name="ff">要处理的字符串</param>
        /// <returns></returns>
        public static string CreateConditionForString(string ff)
        {
            if (string.IsNullOrEmpty(ff))
                return null;
            string[] s = ff.Split(new char[] { ',' });
            string re = "'" + string.Join("','", s) + "'";

            return re;
        }
        #endregion
        

        /// <summary>
        /// 获取实际IP 通过了nginx代理
        /// </summary>
        /// <returns></returns>
        public static string GetRealIPAddress()
        {
            return HttpContext.Current.Request.Headers["X-Real-IP"] ?? HttpContext.Current.Request.UserHostAddress;
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public static string GetIdentityName()
        {
            return HttpContext.Current.Request.LogonUserIdentity.Name;
        }


    }


}