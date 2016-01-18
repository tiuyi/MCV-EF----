using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace JDF.ERP.Common
{
    /// <summary>
    /// Summary description for ImageOperation
    /// </summary>
    /// 
    public class ImageOperation
    {
        /// <summary>    

        /// 生成缩略图    

        /// </summary> 
        /// <param name="originalImagePath">源图路径（物理路径）</param>       
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>        
        /// <param name="towidth">缩略图指定宽度</param>        
        /// <param name="toheight">缩略图指定高度</param>   
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, double towidth, double toheight)
        {
            System.Drawing.Image originalImage = null;
            //新建一个bmp图片         
            System.Drawing.Image bitmap = null;
            //新建一个画板       
            System.Drawing.Graphics g = null;
            try
            {
                originalImage = System.Drawing.Image.FromFile(originalImagePath);
                double proportion1;
                double proportion2;
                int x = 0;
                int y = 0;
                //原图的宽   
                int ow = originalImage.Width;
                //原图的高  
                int oh = originalImage.Height;
            
                proportion1 = toheight / Convert.ToDouble(oh);
                proportion2 = towidth / Convert.ToDouble(ow);
                if (toheight > oh && towidth > ow)
                //如果宽高都小于要缩放的就不缩以与大小缩略   
                {
                    toheight = oh;
                    towidth = ow;
                }
                else
                {
                    //根据比例设定相应的高宽  
                    if (proportion1 > proportion2)
                    {
                        toheight = proportion2 * originalImage.Height;
                    }
                    else
                    {
                        towidth = proportion1 * originalImage.Width;
                    }
                }
                //新建一个bmp图片  
                bitmap = new System.Drawing.Bitmap(Convert.ToInt32(towidth), Convert.ToInt32(toheight));
                //新建一个画板 
                g = System.Drawing.Graphics.FromImage(bitmap);
                //设置高质量插值法     
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                //设置高质量,低速度呈现平滑程度      
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //清空画布并以透明背景色填充    
                g.Clear(System.Drawing.Color.Transparent);
                //在指定位置并且按指定大小绘制原图片的指定部分   
                g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, Convert.ToInt32(towidth), Convert.ToInt32(toheight)), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);
                //以jpg格式保存缩略图WebControls 
                //File.Delete(thumbnailPath);  
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally
            {
                try
                {
                    g.Dispose();
                    bitmap.Dispose();
                    originalImage.Dispose();
                }
                catch (Exception ex2)
                {
                    string a = ex2.Message;
                }
            }
        }
    }
}