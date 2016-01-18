using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Text;
namespace JDF.ERP.Common
{
    /// <summary>
    /// Summary description for ImageAction
    /// </summary>
    public class ImageAction
    {
        /// <summary>/// 获取一个图片按等比例缩小后的大小。
        /// </summary>///
        /// <param name="maxWidth">需要缩小到的宽度</param>
        /// <param name="maxHeight">需要缩小到的高度</param>
        /// <param name="imageOriginalWidth">图片的原始宽度</param>
        /// <param name="imageOriginalHeight">图片的原始高度</param>
        /// <returns>返回图片按等比例缩小后的实际大小</returns>

        public static Size GetNewSize(int maxWidth, int maxHeight, int imageOriginalWidth, int imageOriginalHeight)
        {
            double w = 0.0;
            double h = 0.0;
            double sw = Convert.ToDouble(imageOriginalWidth);
            double sh = Convert.ToDouble(imageOriginalHeight);
            double mw = Convert.ToDouble(maxWidth);
            double mh = Convert.ToDouble(maxHeight);
            if (sw < mw && sh < mh)
            {
                w = sw; h = sh;
            }
            else if ((sw / sh) > (mw / mh))
            {
                w = maxWidth; h = (w * sh) / sw;
            }
            else
            {
                h = maxHeight;
                w = (h * sw) / sh;
            }
            return new Size(Convert.ToInt32(w), Convert.ToInt32(h));
        }
        /// <summary>/// 对给定的一个图片（Image对象）生成一个指定大小的缩略图。
        /// </summary>
        /// <param name="originalImage">原始图片</param>
        /// <param name="thumMaxWidth">缩略图的宽度</param>
        /// <param name="thumMaxHeight">缩略图的高度</param>
        /// <returns>返回缩略图的Image对象
        /// </returns>
        public static System.Drawing.Image GetThumbNailImage(System.Drawing.Image originalImage, int thumMaxWidth, int thumMaxHeight)
        {
            Size thumRealSize = Size.Empty;
            System.Drawing.Image newImage = originalImage;
            Graphics graphics = null;
            try
            {
                thumRealSize = GetNewSize(thumMaxWidth, thumMaxHeight, originalImage.Width, originalImage.Height);
                newImage = new Bitmap(thumRealSize.Width, thumRealSize.Height);
                graphics = Graphics.FromImage(newImage);
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.Clear(Color.Transparent);
                graphics.DrawImage(originalImage, new Rectangle(0, 0, thumRealSize.Width, thumRealSize.Height), new Rectangle(0, 0, originalImage.Width, originalImage.Height), GraphicsUnit.Pixel);
            }
            catch
            {
            }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                    graphics = null;
                }
            }
            return newImage;
        }
        /// <summary>
        /// 对给定的一个图片文件生成一个指定大小的缩略图。
        /// </summary>
        /// <param name="originalImage">图片的物理文件地址</param>
        /// <param name="thumMaxWidth">缩略图的宽度</param>
        /// <param name="thumMaxHeight">缩略图的高度</param>
        /// <returns>返回缩略图的Image对象</returns>
        public static System.Drawing.Image GetThumbNailImage(string imageFile, int thumMaxWidth, int thumMaxHeight)
        {
            System.Drawing.Image originalImage = null;
            System.Drawing.Image newImage = null;
            try
            {
                originalImage = System.Drawing.Image.FromFile(imageFile);
                newImage = GetThumbNailImage(originalImage, thumMaxWidth, thumMaxHeight);
            }
            catch { }
            finally
            {
                if (originalImage != null)
                {
                    originalImage.Dispose(); originalImage = null;
                }
            }
            return newImage;
        }
        /// <summary>
        /// 对给定的一个图片文件生成一个指定大小的缩略图，并将缩略图保存到指定位置。
        /// </summary>
        /// <param name="originalImageFile">图片的物理文件地址</param>
        /// <param name="thumbNailImageFile">缩略图的物理文件地址</param>
        /// <param name="thumMaxWidth">缩略图的宽度</param>
        /// <param name="thumMaxHeight">缩略图的高度</param>
        public static void MakeThumbNail(string originalImageFile, string thumbNailImageFile, int thumMaxWidth, int thumMaxHeight)
        {
            System.Drawing.Image newImage = GetThumbNailImage(originalImageFile, thumMaxWidth, thumMaxHeight);
            try
            {
                newImage.Save(thumbNailImageFile, ImageFormat.Jpeg);
            }
            catch { }
            finally
            {
                newImage.Dispose();
                newImage = null;
            }
        }
        /// <summary>
        /// 将一个图片的内存流调整为指定大小，并返回调整后的内存流。
        /// </summary>
        /// <param name="originalImageStream">原始图片的内存流</param>
        /// <param name="newWidth">新图片的宽度</param>
        /// <param name="newHeight">新图片的高度</param>
        /// <returns>返回调整后的图片的内存流</returns>
        public static MemoryStream ResizeImage(Stream originalImageStream, int newWidth, int newHeight)
        {
            MemoryStream newImageStream = null;
            System.Drawing.Image newImage = GetThumbNailImage(System.Drawing.Image.FromStream(originalImageStream), newWidth, newHeight);
            if (newImage != null)
            {
                newImageStream = new MemoryStream();
                newImage.Save(newImageStream, ImageFormat.Jpeg);
            }
            return newImageStream;
        }
        /// <summary>
        /// 将一个内存流保存为磁盘文件。
        /// </summary>
        /// <param name="stream">内存流</param>
        /// <param name="newFile">目标磁盘文件地址</param>
        public static void SaveStreamToFile(Stream stream, string newFile)
        {
            if (stream == null || stream.Length == 0 || string.IsNullOrEmpty(newFile))
            {
                return;
            }
            byte[] buffer = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(buffer, 0, buffer.Length);
            FileStream fileStream = new FileStream(newFile, FileMode.OpenOrCreate, FileAccess.Write);
            fileStream.Write(buffer, 0, buffer.Length);
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }
        /// <summary>
        /// 对一个指定的图片加上图片水印效果。
        /// </summary>
        /// <param name="imageFile">图片文件地址</param>
        /// <param name="waterImage">水印图片（Image对象）</param>
        public static Stream CreateImageWaterMark(string imageFile, System.Drawing.Image waterImage)
        {
            if (string.IsNullOrEmpty(imageFile) || !File.Exists(imageFile) || waterImage == null)
            {
                return null;
            }
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(imageFile);
            if (originalImage.Width - 10 < waterImage.Width || originalImage.Height - 10 < waterImage.Height)
            { return null; }
            Graphics graphics = Graphics.FromImage(originalImage);
            int x = 10;
            int y = 10;
            int width = waterImage.Width;
            int height = waterImage.Height;
            graphics.DrawImage(waterImage, new Rectangle(x, y, width, height), 0, 0, width, height, GraphicsUnit.Pixel);
            graphics.Dispose();
            MemoryStream stream = new MemoryStream();
            originalImage.Save(stream, ImageFormat.Jpeg);
            originalImage.Dispose();
            return stream;
            //System.Drawing.Image imageWithWater = System.Drawing.Image.FromStream(stream);
            //imageWithWater.Save(imageFile);
            //imageWithWater.Dispose();
        }
        /// <summary>
        /// 对一个指定的图片加上文字水印效果。
        /// </summary>
        /// <param name="imageFile">图片文件地址</param>
        /// <param name="waterText">水印文字内容</param>
        public static void CreateTextWaterMark(string imageFile, string waterText)
        {
            if (string.IsNullOrEmpty(imageFile) || string.IsNullOrEmpty(waterText) || !File.Exists(imageFile))
            { return; }
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(imageFile);
            Graphics graphics = Graphics.FromImage(originalImage);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            SolidBrush brush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));
            Font waterTextFont = new Font("Arial", 16, FontStyle.Regular);
            SizeF waterTextSize = graphics.MeasureString(waterText, waterTextFont);
            float x = (float)originalImage.Width - waterTextSize.Width - 10F;
            float y = (float)originalImage.Height - waterTextSize.Height - 10F;
            graphics.DrawString(waterText, waterTextFont, brush, x, y);
            graphics.Dispose();
            brush.Dispose();
            MemoryStream stream = new MemoryStream();
            originalImage.Save(stream, ImageFormat.Jpeg);
            originalImage.Dispose();
            System.Drawing.Image imageWithWater = System.Drawing.Image.FromStream(stream);
            imageWithWater.Save(imageFile);
            imageWithWater.Dispose();
        }
        /// <summary>
        /// 判断上传组件是否包含内容。
        /// </summary>
        /// <param name="fileUpload">ASP.NET 2.0标准上传组件</param>
        /// <returns>如果数据有效，则返回True，否则返回False</returns>
        public static bool IsAttachmentValid(FileUpload fileUpload)
        {
            if (fileUpload != null && fileUpload.PostedFile != null && !string.IsNullOrEmpty(fileUpload.PostedFile.FileName) && fileUpload.PostedFile.ContentLength > 0)
            {
                return true;
            }
            return false;
        }
    }
}