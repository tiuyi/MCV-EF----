using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

/// <summary>
///CoverHandler 的摘要说明
/// </summary>
namespace XG.Temp.Common
{
    public class MyHandler : IHttpHandler
    {
        public MyHandler()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 图片防止盗链-----图片水印
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {

            //读取图片的路径
            string url = context.Request.RawUrl.ToLower();
            //判断是否为图片
            if (url.EndsWith("jpg") || url.EndsWith("jpeg") || url.EndsWith("png") || url.EndsWith("gif"))//判断图片是不是jpg格式
            {
                //默认图片路径 如果需要加水印的图片不存在的情况下的图片地址
                string ImgURL = "/Resources/no_image.jpg";
                //如果需要加水印的图片存在的话
                if (File.Exists(context.Server.MapPath(context.Request.RawUrl)))
                {
                    ImgURL = context.Request.RawUrl;
                }
                //获取需要加水印的图片
                System.Drawing.Image pic = System.Drawing.Image.FromFile(context.Server.MapPath(ImgURL));
                //获取水印图片
                System.Drawing.Image watermarkImage = System.Drawing.Image.FromFile(context.Server.MapPath("/Images/SYMaster/Smallogo.png"));
                //Graphics 创建制图工具
                Graphics g;
                //如果图片带索引像素格式
                int MaxpicWidth = (pic.Width > 245 ? 245 : pic.Width);
                int MaxpicHeight = (pic.Height > 245 ? 245 : pic.Height);

                //创建对需要加水印的图片 的制图工具
                g = Graphics.FromImage(pic);
                //将水印图片绘制进去
                g.DrawImage(watermarkImage, new Rectangle(MaxpicWidth - watermarkImage.Width - 5, MaxpicHeight - watermarkImage.Height - 5, watermarkImage.Width, watermarkImage.Height), 0, 0, watermarkImage.Width, watermarkImage.Height, GraphicsUnit.Pixel);
                //输出已经加水印的图片
                pic.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);//ImageFormat.Jpeg制定图像的格式

                pic.Dispose();
                watermarkImage.Dispose();
                g.Dispose();
                //将标上水印的图片保存到输出流
                //标明类型为jpg，如果不加，使用IE浏览不会有问题，用FireFox就会是乱码
                //制定输出流的类型
                context.Response.ContentType = "image/jpeg";
                //向客户端发送当前所有缓冲的输出
                context.Response.Flush();
                context.Response.End();
            }
        }

        private static PixelFormat[] indexedPixelFormats = { PixelFormat.Undefined, PixelFormat.DontCare,
      PixelFormat.Format16bppArgb1555, PixelFormat.Format1bppIndexed, PixelFormat.Format4bppIndexed,
      PixelFormat.Format8bppIndexed
    };

        /// <summary>
        /// 判断图片的PixelFormat 是否在 引发异常的 PixelFormat 之中
        /// 无法从带有索引像素格式的图像创建graphics对象
        /// </summary>
        /// <param name="imgPixelFormat">原图片的PixelFormat</param>
        /// <returns></returns>
        private static bool IsPixelFormatIndexed(PixelFormat imgPixelFormat)
        {
            foreach (PixelFormat pf in indexedPixelFormats)
            {
                if (pf.Equals(imgPixelFormat)) return true;
            }

            return false;
        }


        public bool IsReusable
        {
            get { return true; }
        }
    }


}
