using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HPSF;
using NPOI.SS.Util;
using System.Reflection;
using System.Web;
using System.Collections;
using Newtonsoft.Json;
using System.Data.OleDb;
using System.Web.Script.Serialization;




namespace JDF.Finance.Common
{
    /// <summary>
    /// 導出Excel
    /// </summary>
    public class ToExcel
    {
        /// <summary>
        ///  导出excel
        /// </summary>
        /// <param name="dtSource">table数据</param>
        /// <param name="strHeaderText">标题</param>
        /// <param name="strFileName">文件名</param>
        /// <param name="IsDoubleHead">是否双表头</param>
        /// <param name="heads">表头信息</param>
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, bool IsDoubleHead = false, String heads = null, bool isShowHeaderTitle = true, Hashtable ht = null)
        {

            HttpContext curContext = HttpContext.Current;
            string fileName = strFileName;
            //处理乱码兼容性
            if (curContext.Request.UserAgent.ToLower().IndexOf("firefox") > -1)
            {

            }
            else
            {
                fileName = HttpUtility.UrlEncode(strFileName, System.Text.Encoding.UTF8);
            }

            // 设置编码和附件格式  
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + fileName);
            if (isShowHeaderTitle)
            {
                if (IsDoubleHead)
                {
                    if (ht == null)
                    {
                        curContext.Response.BinaryWrite(ExportMoreHead(dtSource, strHeaderText, "", heads).GetBuffer());
                    }
                    else 
                    {
                        curContext.Response.BinaryWrite(ExportMoreHead(dtSource, strHeaderText, "", heads, ht).GetBuffer());
                    }
                }
                else
                {
                    if (ht == null)
                    {
                        curContext.Response.BinaryWrite(Export(dtSource, strHeaderText, "").GetBuffer());
                    }
                    else
                    {
                        curContext.Response.BinaryWrite(Export(dtSource, strHeaderText, "", ht).GetBuffer());
                    }
                }
            }
            else
            {
                curContext.Response.BinaryWrite(ExportNoHeaderTitle(dtSource, strHeaderText, "").GetBuffer());
            }

            curContext.Response.End();
        }


        /// <summary>
        ///  保存Excel文件
        /// </summary>
        /// <param name="dtSource">table数据</param>
        /// <param name="strHeaderText">标题</param>
        /// <param name="SavePah">保存路径</param>
        /// <param name="IsDoubleHead">是否双表头</param>
        /// <param name="heads">表头信息</param>
        public static string SaveByWeb(DataTable dtSource, string strHeaderText, string SavePah, bool IsDoubleHead = false, String heads = null, bool isShowHeaderTitle = true, Hashtable ht = null)
        {
            HttpContext curContext = HttpContext.Current;
            string fileName = Misc.MaxCharacters(System.Guid.NewGuid().ToString(), 10);

            string ShortData = Misc.ConvertToShortDateTime(System.DateTime.Now, "yyyy-MM-dd");
            string savePath = HttpContext.Current.Server.MapPath(SavePah + "//" + ShortData + "//");
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            FileStream fs = new FileStream(savePath + fileName + ".xls", FileMode.OpenOrCreate);
            BinaryWriter w = new BinaryWriter(fs);

            if (isShowHeaderTitle)
            {
                if (IsDoubleHead)
                {
                    w.Write(ExportMoreHead(dtSource, strHeaderText, "", heads).GetBuffer());
                }
                else
                {
                    if (ht == null)
                    {
                        w.Write(Export(dtSource, strHeaderText, "").GetBuffer());
                    }
                    else
                    {
                        w.Write(Export(dtSource, strHeaderText, "", ht).GetBuffer());
                    }
                }
            }
            else
            {
                w.Write(ExportNoHeaderTitle(dtSource, strHeaderText, "").GetBuffer());
            }

            fs.Close();
            w.Close();
            return SavePah + "//" + ShortData + "//" + fileName + ".xls";
        }

        public static MemoryStream Export(DataTable dtSource, string strHeaderText, string hidText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "金大福珠宝";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "金大福珠宝"; //填加xls文件作者信息  
                si.ApplicationName = "金大福珠宝"; //填加xls文件创建程序信息  
                si.LastAuthor = "金大福珠宝"; //填加xls文件最后保存者信息  
                si.Comments = "金大福珠宝"; //填加xls文件作者信息  
                si.Title = "金大福珠宝"; //填加xls文件标题信息  
                si.Subject = "金大福珠宝";//填加文件主题信息  
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            //取得列宽  
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            ICellStyle tdStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }
                    #region 表头及样式
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 30;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    }
                    #endregion
                    {
                        IRow headerRow = sheet.CreateRow(1);
                        if (hidText != "")
                        {
                            hidText += " | ";
                        }
                        headerRow.CreateCell(0).SetCellValue(hidText + "导出时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        headerRow.HeightInPoints = 18;
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Right;
                        headStyle.Indention = 50;
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, dtSource.Columns.Count - 1));
                    }
                    #region 列头及样式
                    {
                        IRow headerRow = sheet.CreateRow(2);
                        headerRow.HeightInPoints = 18;
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Left;
                        headStyle.VerticalAlignment = VerticalAlignment.Center;
                        headStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Green.Index;
                        headStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                        headStyle.BorderBottom = BorderStyle.Thin;
                        headStyle.BorderLeft = BorderStyle.Thin;
                        headStyle.BorderRight = BorderStyle.Thin;
                        headStyle.BorderTop = BorderStyle.Thin;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        font.Color = NPOI.HSSF.Util.HSSFColor.White.Index;
                        headStyle.SetFont(font);

                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                            //设置列宽  
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                    }
                    #endregion
                    rowIndex = 3;
                }
                #endregion

                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                dataRow.HeightInPoints = 18;
                //if (rowIndex % 2 == 0)
                //    tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.GREY_25_PERCENT.index;
                //else
                //    tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.index;
                tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
                tdStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                ////设置单元格边框 
                tdStyle.BorderBottom = BorderStyle.Thin;
                tdStyle.BorderLeft = BorderStyle.Thin;
                tdStyle.BorderRight = BorderStyle.Thin;
                tdStyle.BorderTop = BorderStyle.Thin;
                tdStyle.VerticalAlignment = VerticalAlignment.Center;
                short datet = workbook.CreateDataFormat().GetFormat("yyyy-mm-dd");
                bool isCell = dtSource.Rows.Count < 4000;//4000行bug
                InitRowData(dtSource, tdStyle, row, dataRow, isCell);
                #endregion
                rowIndex++;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                return ms;
            }
        }

        public static MemoryStream Export(DataTable dtSource, string strHeaderText, string hidText, Hashtable ht = null)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "金大福珠宝";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "金大福珠宝"; //填加xls文件作者信息  
                si.ApplicationName = "金大福珠宝"; //填加xls文件创建程序信息  
                si.LastAuthor = "金大福珠宝"; //填加xls文件最后保存者信息  
                si.Comments = "金大福珠宝"; //填加xls文件作者信息  
                si.Title = "金大福珠宝"; //填加xls文件标题信息  
                si.Subject = "金大福珠宝";//填加文件主题信息  
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽  
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }

            int rowIndex = 0;
            ICellStyle tdStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {//如果行不是0（第一行，则重新建一个表）
                        sheet = workbook.CreateSheet();
                    }
                    #region 表头及样式（第一行）
                    {
                        IRow headerRow = sheet.CreateRow(0); //创建第一行(逻辑第0行)
                        headerRow.HeightInPoints = 30;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    }
                    #endregion
                    //第二行
                    {
                        IRow headerRow = sheet.CreateRow(1);

                        var indexs = new int[0];
                        var strs = new string[0];

                        //赋值
                        if (ht != null && ht["indexs"] != null && ht["strs"] != null)
                        {
                            if (ht["indexs"] is int[] && ht["strs"] is string[])
                            {
                                var comonIndex = 0;
                                var isMerge = false;
                                indexs = (int[])ht["indexs"];
                                strs = (string[])ht["strs"];
                                if (indexs.Length > 0 && indexs.Length <= strs.Length && indexs[indexs.Length - 1] <= dtSource.Columns.Count - 1)
                                {
                                    //Array.Sort(index);
                                    for (int i = 0; i < dtSource.Columns.Count; i++)
                                    {
                                        for (var j = 0; j < indexs.Length; j++)
                                        {
                                            if (i == indexs[j])
                                            {
                                                comonIndex = j;
                                                isMerge = true;
                                                break;
                                            }
                                        }
                                        if (isMerge) { headerRow.CreateCell(i).SetCellValue(strs[comonIndex]); }
                                        else { headerRow.CreateCell(i).SetCellValue(""); }

                                        isMerge = false;
                                        comonIndex = 0;
                                    }
                                }
                            }
                        }

                        headerRow.HeightInPoints = 18;
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        headStyle.Indention = 50;


                        //合并单元格
                        if (indexs.Length > 1 && indexs[0] >= 0 && indexs.Length <= strs.Length) 
                        {
                            for (var index=0;index<indexs.Length;index++) 
                            {
                                if (index == indexs.Length -1) 
                                {
                                    var cra = new CellRangeAddress(1, 1, indexs[index], dtSource.Columns.Count-1);
                                    sheet.AddMergedRegion(cra);
                                }
                                else
                                {
                                    var cra = new CellRangeAddress(1, 1, indexs[index], indexs[index + 1] - 1);
                                    sheet.AddMergedRegion(cra);
                                }
                               
                            }
                        }                     
                    }
                    #region 列头及样式 （第三行）
                    {
                        IRow headerRow = sheet.CreateRow(2);
                        headerRow.HeightInPoints = 18;
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Left;
                        headStyle.VerticalAlignment = VerticalAlignment.Center;
                        headStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Green.Index;
                        headStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                        headStyle.BorderBottom = BorderStyle.Thin;
                        headStyle.BorderLeft = BorderStyle.Thin;
                        headStyle.BorderRight = BorderStyle.Thin;
                        headStyle.BorderTop = BorderStyle.Thin;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        font.Color = NPOI.HSSF.Util.HSSFColor.White.Index;
                        headStyle.SetFont(font);

                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                            //设置列宽  
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                    }
                    #endregion
                    rowIndex = 3;
                }
                #endregion

                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                dataRow.HeightInPoints = 18;
                //if (rowIndex % 2 == 0)
                //    tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.GREY_25_PERCENT.index;
                //else
                //    tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.index;
                tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
                tdStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                ////设置单元格边框 
                tdStyle.BorderBottom = BorderStyle.Thin;
                tdStyle.BorderLeft = BorderStyle.Thin;
                tdStyle.BorderRight = BorderStyle.Thin;
                tdStyle.BorderTop = BorderStyle.Thin;
                tdStyle.VerticalAlignment = VerticalAlignment.Center;
                short datet = workbook.CreateDataFormat().GetFormat("yyyy-mm-dd");
                bool isCell = dtSource.Rows.Count < 4000;//4000行bug
                InitRowData(dtSource, tdStyle, row, dataRow, isCell);
                #endregion
                rowIndex++;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                return ms;
            }
        }

        /// <summary>
        /// 多表头导出excel
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText"></param>
        /// <param name="hidText"></param>
        /// <returns></returns>
        public static MemoryStream ExportMoreHead(DataTable dtSource, string strHeaderText, string hidText, string heads)
        {
            if (heads.Contains("},]"))
            {
                heads = heads.Substring(0, heads.Length - 2) + "]";
            }
            List<ReportTableHead> model = JsonConvert.DeserializeObject<List<ReportTableHead>>(heads); //表头
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "金大福珠宝";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "金大福珠宝"; //填加xls文件作者信息  
                si.ApplicationName = "金大福珠宝"; //填加xls文件创建程序信息  
                si.LastAuthor = "金大福珠宝"; //填加xls文件最后保存者信息  
                si.Comments = "金大福珠宝"; //填加xls文件作者信息  
                si.Title = "金大福珠宝"; //填加xls文件标题信息  
                si.Subject = "金大福珠宝";//填加文件主题信息  
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            //取得列宽  
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            ICellStyle tdStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }
                    #region 表头及样式
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 30;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    }
                    #endregion
                    {
                        IRow headerRow = sheet.CreateRow(1);
                        if (hidText != "")
                        {
                            hidText += " | ";
                        }
                        headerRow.CreateCell(0).SetCellValue(hidText + "导出时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        headerRow.HeightInPoints = 18;
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Right;
                        headStyle.Indention = 50;
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, dtSource.Columns.Count - 1));
                    }
                    #region 列头及样式
                    {
                        IRow headerRow1 = sheet.CreateRow(2);
                        IRow headerRow2 = sheet.CreateRow(3);

                        headerRow2.HeightInPoints = 18;
                        headerRow1.HeightInPoints = 18;
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Left;
                        headStyle.VerticalAlignment = VerticalAlignment.Center;
                        headStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Green.Index;
                        headStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                        headStyle.BorderBottom = BorderStyle.Thin;
                        headStyle.BorderLeft = BorderStyle.Thin;
                        headStyle.BorderRight = BorderStyle.Thin;
                        headStyle.BorderTop = BorderStyle.Thin;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        font.Color = NPOI.HSSF.Util.HSSFColor.White.Index;
                        headStyle.SetFont(font);

                        List<int> li = new List<int>();
                        for (int i = 0; i < model.Count; i++)
                        {
                            headStyle.Alignment = HorizontalAlignment.Center;
                            int start = model[i].startCell;
                            int end = model[i].endCell;
                            sheet.AddMergedRegion(new CellRangeAddress(2, 2, start, end));
                            headerRow1.CreateCell(start).SetCellValue(model[i].Title);
                            headerRow1.GetCell(start).CellStyle = headStyle;


                            for (int j = start; j <= end; j++)
                            {
                                li.Add(j);
                            }
                        }

                        foreach (DataColumn column in dtSource.Columns)
                        {
                            if (li.Contains(column.Ordinal))
                            {
                                sheet.AddMergedRegion(new CellRangeAddress(3, 3, column.Ordinal, column.Ordinal));
                                headerRow2.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow2.GetCell(column.Ordinal).CellStyle = headStyle;
                                //设置列宽  
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                            }
                            else
                            {
                                headerRow1.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

                                headerRow1.GetCell(column.Ordinal).CellStyle = headStyle;

                                //设置列宽  
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                                sheet.AddMergedRegion(new CellRangeAddress(2, 3, column.Ordinal, column.Ordinal));
                            }

                        }


                    }
                    #endregion
                    rowIndex = 4;
                }
                #endregion

                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                dataRow.HeightInPoints = 18;


                //if (rowIndex % 2 == 0)
                //    tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.GREY_25_PERCENT.index;
                //else
                //    tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.index;
                tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
                tdStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                ////设置单元格边框 
                tdStyle.BorderBottom = BorderStyle.Thin;
                tdStyle.BorderLeft = BorderStyle.Thin;
                tdStyle.BorderRight = BorderStyle.Thin;
                tdStyle.BorderTop = BorderStyle.Thin;
                tdStyle.VerticalAlignment = VerticalAlignment.Center;
                short datet = workbook.CreateDataFormat().GetFormat("yyyy-mm-dd");
                bool isCell = dtSource.Rows.Count < 4000;//4000行bug
                InitRowData(dtSource, tdStyle, row, dataRow, isCell);
                #endregion
                rowIndex++;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                return ms;
            }
        }

        public static MemoryStream ExportMoreHead(DataTable dtSource, string strHeaderText, string hidText, string heads,Hashtable ht=null)
        {
            if (heads.Contains("},]"))
            {
                heads = heads.Substring(0, heads.Length - 2) + "]";
            }
            List<ReportTableHead> model = JsonConvert.DeserializeObject<List<ReportTableHead>>(heads); //表头
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "金大福珠宝";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "金大福珠宝"; //填加xls文件作者信息  
                si.ApplicationName = "金大福珠宝"; //填加xls文件创建程序信息  
                si.LastAuthor = "金大福珠宝"; //填加xls文件最后保存者信息  
                si.Comments = "金大福珠宝"; //填加xls文件作者信息  
                si.Title = "金大福珠宝"; //填加xls文件标题信息  
                si.Subject = "金大福珠宝";//填加文件主题信息  
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            //取得列宽  
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            ICellStyle tdStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }
                    #region 表头及样式
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 30;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    }
                    #endregion
                    //{
                    //    IRow headerRow = sheet.CreateRow(1);
                    //    if (hidText != "")
                    //    {
                    //        hidText += " | ";
                    //    }
                    //    headerRow.CreateCell(0).SetCellValue(hidText + "导出时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    //    headerRow.HeightInPoints = 18;
                    //    ICellStyle headStyle = workbook.CreateCellStyle();
                    //    headStyle.Alignment = HorizontalAlignment.Right;
                    //    headStyle.Indention = 50;
                    //    headerRow.GetCell(0).CellStyle = headStyle;
                    //    sheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, dtSource.Columns.Count - 1));
                    //}

                    {
                        IRow headerRow = sheet.CreateRow(1);

                        var indexs = new int[0];
                        var strs = new string[0];

                        //赋值
                        if (ht != null && ht["indexs"] != null && ht["strs"] != null)
                        {
                            if (ht["indexs"] is int[] && ht["strs"] is string[])
                            {
                                var comonIndex = 0;
                                var isMerge = false;
                                indexs = (int[])ht["indexs"];
                                strs = (string[])ht["strs"];
                                if (indexs.Length > 0 && indexs.Length <= strs.Length && indexs[indexs.Length - 1] <= dtSource.Columns.Count - 1)
                                {
                                    //Array.Sort(index);
                                    for (int i = 0; i < dtSource.Columns.Count; i++)
                                    {
                                        for (var j = 0; j < indexs.Length; j++)
                                        {
                                            if (i == indexs[j])
                                            {
                                                comonIndex = j;
                                                isMerge = true;
                                                break;
                                            }
                                        }
                                        if (isMerge) { headerRow.CreateCell(i).SetCellValue(strs[comonIndex]); }
                                        else { headerRow.CreateCell(i).SetCellValue(""); }

                                        isMerge = false;
                                        comonIndex = 0;
                                    }
                                }
                            }
                        }

                        headerRow.HeightInPoints = 18;
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        headStyle.Indention = 50;


                        //合并单元格
                        if (indexs.Length > 1 && indexs[0] >= 0 && indexs.Length <= strs.Length)
                        {
                            for (var index = 0; index < indexs.Length; index++)
                            {
                                if (index == indexs.Length - 1)
                                {
                                    var cra = new CellRangeAddress(1, 1, indexs[index], dtSource.Columns.Count - 1);
                                    sheet.AddMergedRegion(cra);
                                }
                                else
                                {
                                    var cra = new CellRangeAddress(1, 1, indexs[index], indexs[index + 1] - 1);
                                    sheet.AddMergedRegion(cra);
                                }

                            }
                        }
                    }



                    #region 列头及样式
                    {
                        IRow headerRow1 = sheet.CreateRow(2);
                        IRow headerRow2 = sheet.CreateRow(3);

                        headerRow2.HeightInPoints = 18;
                        headerRow1.HeightInPoints = 18;
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Left;
                        headStyle.VerticalAlignment = VerticalAlignment.Center;
                        headStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Green.Index;
                        headStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                        headStyle.BorderBottom = BorderStyle.Thin;
                        headStyle.BorderLeft = BorderStyle.Thin;
                        headStyle.BorderRight = BorderStyle.Thin;
                        headStyle.BorderTop = BorderStyle.Thin;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        font.Color = NPOI.HSSF.Util.HSSFColor.White.Index;
                        headStyle.SetFont(font);

                        List<int> li = new List<int>();
                        for (int i = 0; i < model.Count; i++)
                        {
                            headStyle.Alignment = HorizontalAlignment.Center;
                            int start = model[i].startCell;
                            int end = model[i].endCell;
                            sheet.AddMergedRegion(new CellRangeAddress(2, 2, start, end));
                            headerRow1.CreateCell(start).SetCellValue(model[i].Title);
                            headerRow1.GetCell(start).CellStyle = headStyle;


                            for (int j = start; j <= end; j++)
                            {
                                li.Add(j);
                            }
                        }

                        foreach (DataColumn column in dtSource.Columns)
                        {
                            if (li.Contains(column.Ordinal))
                            {
                                sheet.AddMergedRegion(new CellRangeAddress(3, 3, column.Ordinal, column.Ordinal));
                                headerRow2.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow2.GetCell(column.Ordinal).CellStyle = headStyle;
                                //设置列宽  
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                            }
                            else
                            {
                                headerRow1.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

                                headerRow1.GetCell(column.Ordinal).CellStyle = headStyle;

                                //设置列宽  
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                                sheet.AddMergedRegion(new CellRangeAddress(2, 3, column.Ordinal, column.Ordinal));
                            }

                        }


                    }
                    #endregion
                    rowIndex = 4;
                }
                #endregion

                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                dataRow.HeightInPoints = 18;


                //if (rowIndex % 2 == 0)
                //    tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.GREY_25_PERCENT.index;
                //else
                //    tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.index;
                tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
                tdStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                ////设置单元格边框 
                tdStyle.BorderBottom = BorderStyle.Thin;
                tdStyle.BorderLeft = BorderStyle.Thin;
                tdStyle.BorderRight = BorderStyle.Thin;
                tdStyle.BorderTop = BorderStyle.Thin;
                tdStyle.VerticalAlignment = VerticalAlignment.Center;
                short datet = workbook.CreateDataFormat().GetFormat("yyyy-mm-dd");
                bool isCell = dtSource.Rows.Count < 4000;//4000行bug
                InitRowData(dtSource, tdStyle, row, dataRow, isCell);
                #endregion
                rowIndex++;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                return ms;
            }
        }

        public static MemoryStream ExportNoHeaderTitle(DataTable dtSource, string strHeaderText, string hidText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "金大福珠宝";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "金大福珠宝"; //填加xls文件作者信息  
                si.ApplicationName = "金大福珠宝"; //填加xls文件创建程序信息  
                si.LastAuthor = "金大福珠宝"; //填加xls文件最后保存者信息  
                si.Comments = "金大福珠宝"; //填加xls文件作者信息  
                si.Title = "金大福珠宝"; //填加xls文件标题信息  
                si.Subject = "金大福珠宝";//填加文件主题信息  
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            //取得列宽  
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            ICellStyle tdStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }
                    #region 列头及样式
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 18;
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Left;
                        headStyle.VerticalAlignment = VerticalAlignment.Center;
                        headStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Green.Index;
                        headStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                        headStyle.BorderBottom = BorderStyle.Thin;
                        headStyle.BorderLeft = BorderStyle.Thin;
                        headStyle.BorderRight = BorderStyle.Thin;
                        headStyle.BorderTop = BorderStyle.Thin;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        font.Color = NPOI.HSSF.Util.HSSFColor.White.Index;
                        headStyle.SetFont(font);

                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                            //设置列宽  
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                    }
                    #endregion
                    rowIndex = 1;
                }
                #endregion

                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                dataRow.HeightInPoints = 18;
                //if (rowIndex % 2 == 0)
                //    tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.GREY_25_PERCENT.index;
                //else
                //    tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.index;
                tdStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
                tdStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                ////设置单元格边框 
                tdStyle.BorderBottom = BorderStyle.Thin;
                tdStyle.BorderLeft = BorderStyle.Thin;
                tdStyle.BorderRight = BorderStyle.Thin;
                tdStyle.BorderTop = BorderStyle.Thin;
                tdStyle.VerticalAlignment = VerticalAlignment.Center
;
                short datet = workbook.CreateDataFormat().GetFormat("yyyy-mm-dd");
                bool isCell = dtSource.Rows.Count < 4000;//4000行bug
                InitRowData(dtSource, tdStyle, row, dataRow, isCell);
                #endregion
                rowIndex++;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                return ms;
            }
        }

        private static void InitRowData(DataTable dtSource, ICellStyle tdStyle, DataRow row, IRow dataRow, bool isCell)
        {
            foreach (DataColumn column in dtSource.Columns)
            {
                ICell newCell = dataRow.CreateCell(column.Ordinal);
                if (isCell) newCell.CellStyle = tdStyle;
                string drValue = row[column].ToString();
                if (column.ColumnName.Contains("条码") || column.ColumnName.Contains("条形码"))
                {
                    newCell.SetCellValue(drValue);
                    continue;
                }
                if (drValue.Length >= 15)
                    newCell.SetCellValue(drValue);
                else
                {
                    double doubV = 0;
                    if (double.TryParse(drValue, out doubV))
                        newCell.SetCellValue(doubV);
                    else
                        newCell.SetCellValue(drValue);
                }


                //switch (column.DataType.ToString())
                //{
                //    case "System.String"://字符串类型  
                //        newCell.SetCellValue(drValue);
                //        break;
                //    case "System.DateTime"://日期类型  
                //        //表格样式增加格式化日期 ---20120821
                //        //tdStyle.DataFormat = datet;
                //        DateTime dateV;
                //        DateTime.TryParse(drValue, out dateV);
                //        newCell.SetCellValue(dateV);
                //        break;
                //    case "System.Boolean"://布尔型  
                //        bool boolV = false;
                //        bool.TryParse(drValue, out boolV);
                //        newCell.SetCellValue(boolV);
                //        break;
                //    case "System.Int16"://整型  
                //    case "System.Int32":
                //    case "System.Int64":
                //    case "System.Byte":
                //        int intV = 0;
                //        int.TryParse(drValue, out intV);
                //        newCell.SetCellValue(intV);
                //        break;
                //    case "System.Decimal"://浮点型  
                //    case "System.Double":
                //        double doubV = 0;
                //        double.TryParse(drValue, out doubV);
                //        newCell.SetCellValue(doubV);
                //        break;
                //    case "System.DBNull"://空值处理  
                //        newCell.SetCellValue("");
                //        break;
                //    default:
                //        newCell.SetCellValue("");
                //        break;
                //}

            }
        }

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="list">泛类型集合</param>
        /// <param name="list">需要保留的字段</param>
        /// <param name="list">字段對應的中文名稱</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(IList<T> entitys, string[] field, string[] name)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                return null;
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            int[] index = new int[field.Length];
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < entityProperties.Length; j++)
                {
                    if (entityProperties[j].Name == field[i])
                    {
                        index[dt.Columns.Count] = j;
                        //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                        dt.Columns.Add(name[i]);
                        break;
                    }

                }

            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[name.Length];
                for (int i = 0; i < name.Length; i++)
                {
                    entityValues[i] = entityProperties[index[i]].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }

        /// <summary>
        /// 对dt进行处理，改中文列名，列排序，设置列格式
        /// </summary>
        /// <param name="dt">dt</param>
        /// <param name="names">中文列名</param>
        /// <param name="field">列名（可以传null）</param>
        /// <param name="hs">列名和对应的数据类型(可传null)</param>
        /// <returns></returns>
        public static DataTable SetDataTableColmName(DataTable dt, string[] names, string[] field, Hashtable hs)
        {
            DataTable table = new DataTable();
            if (dt.Rows.Count > 0)
            {

                if (field != null && field.Length > 0) //如果field不为空 则按照field的列的顺序进行排序，且field列和names的中文列名顺序一一对应
                {
                    DataTable newDt = new DataTable();
                    //建表结构
                    for (int i = 0; i < field.Length; i++)
                    {
                        if (!dt.Columns.Contains(field[i].ToString()))
                        {
                            continue;

                        }
                        DataColumn cl = new DataColumn();
                        cl.ColumnName = field[i].ToString();

                        if (dt.Columns[cl.ColumnName].DataType != typeof(System.DateTime))
                        {
                            cl.DataType = dt.Columns[cl.ColumnName].DataType;
                        }
                        else
                        {
                            cl.DataType = typeof(String);
                        }

                        if (hs != null)
                        {
                            foreach (DictionaryEntry deHB in hs)
                            {
                                if (deHB.Key.ToString().ToLower() == field[i].ToString().ToLower())
                                {
                                    cl.DataType = (Type)deHB.Value;
                                    break;
                                }
                            }
                        }

                        newDt.Columns.Add(cl);
                    }

                    //填数据
                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow r = newDt.NewRow();
                        foreach (DataColumn clm in newDt.Columns)
                        {

                            r[clm] = row[clm.ColumnName];
                        }
                        newDt.Rows.Add(r);
                    }

                    //改列名
                    foreach (DataColumn dc in newDt.Columns)
                    {
                        dc.ColumnName = names[dc.Ordinal];
                    }

                    table = newDt;

                }
                else //field为空，列的顺序就按照dt的顺序，且names的中文名和dt的列顺序一一对应
                {
                    DataTable dt1 = dt.Copy();

                    if (names.Length != dt1.Columns.Count)
                    {
                        throw new Exception("必须为给个列一一对应的中文名称！");
                    }
                    foreach (DataColumn dc in dt1.Columns)
                    {

                        //foreach (DictionaryEntry deHB in hs)
                        //{
                        //    if (deHB.Key.ToString() == dc.ColumnName.ToString())
                        //    {
                        //        dc.DataType = deHB.Value.GetType();
                        //    }
                        //}
                        dc.ColumnName = names[dc.Ordinal];
                    }
                    dt1.AcceptChanges();
                    table = dt1;

                }

            }
            return table;

        }


        /// <summary>
        ///  npoi 基于模版导出excel 
        /// </summary>
        /// <param name="excelPath">模版位置</param>
        /// <param name="dt">需处理数据</param>
        /// <param name="k">表头所占行数</param>
        /// <returns></returns>
        public MemoryStream NpoiBaseExcelForDown(string excelPath, DataTable dt, int k)
        {
            FileStream file = new FileStream(excelPath, FileMode.Open, FileAccess.Read);

            IWorkbook hssfworkbook = WorkbookFactory.Create(file);
            //IWorkbook hssfworkbook = null;
            //try
            //{
            //    hssfworkbook = new XSSFWorkbook(file);
            //}
            //catch (Exception)
            //{
            //    hssfworkbook = new HSSFWorkbook(file);
            //}

            ISheet sheet1 = hssfworkbook.GetSheet("Sheet1");


            int r_count = dt.Rows.Count;
            int c_count = dt.Columns.Count;
            //插入查询结果
            for (int i = 0; i < r_count; i++)
            {
                // IRow row = sheet1.CreateRow(i);
                IRow row = sheet1.CreateRow(i + k);//从第二行开始
                for (int j = 0; j < c_count; j++)
                {
                    row.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }



            sheet1.ForceFormulaRecalculation = true;
            //FileStream file = new FileStream(@"test.xls", FileMode.Create); hssfworkbook.Write(file); file.Close();  

            MemoryStream memoryStream = new MemoryStream();
            hssfworkbook.Write(memoryStream);
            return memoryStream;


        }


        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="sheet">要合并单元格所在的sheet</param>
        /// <param name="rowstart">开始行的索引</param>
        /// <param name="rowend">结束行的索引</param>
        /// <param name="colstart">开始列的索引</param>
        /// <param name="colend">结束列的索引</param>
        public static void SetCellRangeAddress(ISheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
        }

        /// <summary>
        /// 读取服务器上的Execl文件
        /// </summary>
        /// <param name="Path">物理地址：c:\a.xls/</param>
        /// <returns>DataSet</returns>
        public static DataSet ExcelToDS(string Path)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            conn.Close();
            return ds;
        }


        /// <summary>
        /// 将对象转换成josn字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJSON(object sender)
        {
            StringBuilder builder = new StringBuilder();
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            try
            {
                serializer.Serialize(sender, builder);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.ErrorMess("JSONHelper" + " : " + ex.Message);
            }

            return builder.ToString();
        }

        /// <summary>
        /// 创建打印json文件
        /// </summary>
        /// <param name="strTemplateName">模版名称</param>
        /// <param name="strJsonString">json字符串</param>
        /// <returns></returns>
        public static void CreateJsonFile(string strTemplateName, string strJsonString)
        {
            FileStream fs = new FileStream(strTemplateName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);//开始写入
            sw.Write(strJsonString);//写入
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }


        public static T JsonStrToT<T>(string jsonStr)where T: new()
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Deserialize<T>(jsonStr);
            }
            catch 
            {
                return new T();
            }
        }

        /// <summary>
        /// 将json字符串转换成Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T ConvertJsonToT<T>(T t, string jsonStr) where T : class,new()
        {
            if (t == null) { return t; }
            else
            {
                Type tp = t.GetType();
                PropertyInfo[] propertys = tp.GetProperties();

                if (!string.IsNullOrEmpty(jsonStr))
                {
                    #region 处理字符串
                    var strarr = jsonStr.Replace("{", "}");
                    strarr = strarr.Replace("}", "");
                    strarr = strarr.Replace("\"", "");
                    var arr = strarr.Split(',');
                    #endregion

                    string name = "";

                    foreach (var p in propertys)
                    {
                        var obj = p.PropertyType;
                        name = obj.Name;

                        foreach (var v in arr)
                        {
                            var dic = v.Split(':');

                            if (dic.Length > 0 && dic[0] != "" && dic[0] == p.Name)
                            {
                                if (name == "String")
                                {
                                    tp.GetProperty(p.Name).SetValue(t, dic[1], null);
                                }
                                else if (name == "Int32")
                                {
                                    int tempValue = 0;
                                    if (int.TryParse(dic[1], out tempValue))
                                    {
                                        tp.GetProperty(p.Name).SetValue(t, tempValue, null);
                                    }
                                }
                                else if (name == "Decimal")
                                {
                                    decimal tempValue = 0;
                                    if (decimal.TryParse(dic[1], out tempValue))
                                    {
                                        tp.GetProperty(p.Name).SetValue(t, tempValue, null);
                                    }
                                }
                                else if (name == "DateTime")
                                {
                                    DateTime tempValue;
                                    if (DateTime.TryParse(dic[1], out tempValue))
                                    {
                                        tp.GetProperty(p.Name).SetValue(t, tempValue, null);
                                    }
                                }
                                else if (name == "Double")
                                {
                                    double tempValue;
                                    if (double.TryParse(dic[1], out tempValue))
                                    {
                                        tp.GetProperty(p.Name).SetValue(t, tempValue, null);
                                    }
                                }
                                else if (name == "Nullable`1")
                                {
                                    var fnamet = obj.FullName;
                                    fnamet = fnamet.Replace("System.Nullable`1", "");
                                    fnamet = fnamet.Remove(fnamet.Length - 2);
                                    fnamet = fnamet.Remove(0, 2);
                                    var arrs = fnamet.Split(',');
                                    var fullnameTemp = arrs[0];

                                    if (fullnameTemp == "System.Int32") 
                                    {
                                        int tempValue = 0;
                                        if (int.TryParse(dic[1], out tempValue))
                                        {
                                            tp.GetProperty(p.Name).SetValue(t, tempValue, null);
                                        }
                                    }                                 
                                    else if (fullnameTemp == "System.Double") 
                                    {
                                        double tempValue = 0;
                                        if (double.TryParse(dic[1], out tempValue))
                                        {
                                            tp.GetProperty(p.Name).SetValue(t, tempValue, null);
                                        }
                                    }
                                    else if (fullnameTemp == "System.Decimal") 
                                    {
                                        decimal tempValue = 0;
                                        if (decimal.TryParse(dic[1], out tempValue))
                                        {
                                            tp.GetProperty(p.Name).SetValue(t, tempValue, null);
                                        }
                                    }
                                    else if (fullnameTemp == "System.DateTime") 
                                    {
                                        DateTime tempValue;
                                        if (DateTime.TryParse(dic[1], out tempValue))
                                        {
                                            tp.GetProperty(p.Name).SetValue(t, tempValue, null);
                                        }
                                    }
                                }

                                break;
                            }
                        }
                    }
                }
            }

            return t;
        }

    }

    /// <summary>
    /// 表头
    /// </summary>
    public class ReportTableHead
    {
        public string Title { get; set; }
        public int startCell { get; set; }
        public int endCell { get; set; }

    }
}
