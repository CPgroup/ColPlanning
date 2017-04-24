using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Threading;

namespace CoScheduling.Main.Task
{
    public class WordHelper
    {
        private _Application wordApp = null;
        private _Document wordDoc = null;
        public _Application Application
        {
            get
            {
                return wordApp;
            }
            set
            {
                wordApp = value;
            }
        }
        public _Document Document
        {
            get
            {
                return wordDoc;
            }
            set
            {
                wordDoc = value;
            }
        }

        /// <summary>
        /// 通过模板创建新文档
        /// </summary>
        /// <param name="filePath"></param>
        public void CreateNewDocument(string filePath)
        {
            try
            {
                //killWinWordProcess();
                wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                wordApp.Visible = false;
                object missing = System.Reflection.Missing.Value;
                object templateName = filePath;
                //wordDoc =wordApp.Documents.Add(ref Nothing, ref Nothing,ref Nothing, ref Nothing);
                wordDoc = wordApp.Documents.Open(ref templateName, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        /// <summary>
        /// 保存新文件
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveDocument(string filePath)
        {
            object fileName = filePath;
            object format = WdSaveFormat.wdFormatDocument;//保存格式
            object miss = System.Reflection.Missing.Value;
            wordDoc.SaveAs(ref fileName, ref miss, ref miss,
                ref miss, ref miss, ref miss, ref miss,
                ref miss, ref miss, ref miss, ref miss,
                ref miss, ref miss, ref miss, ref miss,
                ref miss);
            //关闭wordDoc，wordApp对象
            object SaveChanges = WdSaveOptions.wdSaveChanges;
            object OriginalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
            object RouteDocument = false;
            wordDoc.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            wordApp.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
        }

        //在书签处插入值
        /// <summary>
        /// 在标签处插入值
        /// </summary>
        /// <param name="bookmark">标签</param>
        /// <param name="value">字段</param>
        /// <param name="pFontSize">字体大小</param>
        /// <param name="pFontColor">字体颜色</param>
        /// <param name="pFontBold">字体粗体</param>
        /// <param name="ptextAlignment">字体方向</param>
        /// <returns></returns>
        public bool InsertValue(string bookmark, string value, int pFontSize, Microsoft.Office.Interop.Word.WdColor pFontColor, int pFontBold, Microsoft.Office.Interop.Word.WdParagraphAlignment ptextAlignment)
        {
            object bkObj = bookmark;
            if (wordApp.ActiveDocument.Bookmarks.Exists(bookmark))
            {
                wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();
                wordApp.Selection.Font.Size = pFontSize;
                wordApp.Selection.Font.Color = pFontColor;
                wordApp.Selection.Font.Bold = pFontBold;
                wordApp.Selection.ParagraphFormat.Alignment = ptextAlignment;
                wordApp.Selection.TypeText(value);
                return true;
            }
            return false;
        }
        public void SetFormatandSize(Microsoft.Office.Interop.Word.Table table, int row1, int column1, int pFontSize, int pFontBold)
        {
            table.Cell(row1, column1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            table.Cell(row1, column1).Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Cell(row1, column1).Range.Font.Size = pFontSize;
            table.Cell(row1, column1).Range.Font.Bold = pFontBold;
        }
        public void SetFormat(Microsoft.Office.Interop.Word.Table table, int row1, int column1)
        {
            table.Cell(row1, column1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            table.Cell(row1, column1).Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        }
        public void SetTableFormat(int n, int Align, int Vertical)
        {
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            switch (Align)
            {
                case -1: table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft; break;//左对齐
                case 0: table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter; break;//水平居中
                case 1: table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight; break;//右对齐
            }
            switch (Vertical)
            {
                case -1: table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalTop; break;//顶端对齐
                case 0: table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; break;//垂直居中
                case 1: table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom; break;//底端对齐
            }
        }

        /// <summary>
        /// 插入表格
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="rows"></param> 
        /// <param name="columns"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public Table InsertTable(string bookmark, int rows, int columns, float width)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            Range range = wordDoc.Bookmarks.get_Item(ref oStart).Range;//表格插入位置
            Table newTable = wordDoc.Tables.Add(range, rows, columns, ref miss, ref miss);
            //设置表的格式
            newTable.Borders.Enable = 1;  //允许有边框，默认没有边框(为0时报错，1为实线边框，2、3为虚线边框，以后的数字没试过)
            newTable.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth050pt;//边框宽度
            if (width != 0)
            {
                newTable.PreferredWidth = width;//表格宽度
            }
            newTable.AllowPageBreaks = false;
            return newTable;
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="row1">开始行号</param>
        /// <param name="column1">开始列号</param>
        /// <param name="row2">结束行号</param>
        /// <param name="column2">结束列号</param>
        public void MergeCell(Microsoft.Office.Interop.Word.Table table, int row1, int column1, int row2, int column2)
        {
            table.Cell(row1, column1).Merge(table.Cell(row2, column2));
            // Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
        }
        public void MergeCellS(int n, int row1, int column1, int row2, int column2)
        {
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            table.Cell(row1, column1).Merge(table.Cell(row2, column2));

        }
        //设置表格内容对齐方式 Align水平方向，Vertical垂直方向(左对齐，居中对齐，右对齐分别对应Align和Vertical的值为-1,0,1)
        /// <summary>
        /// 设置表格内容对齐方式 Align水平方向
        /// </summary>
        /// <param name="table"></param>
        /// <param name="Align"></param>
        /// <param name="Vertical"></param>
        public void SetParagraph_Table(Microsoft.Office.Interop.Word.Table table, int Align, int Vertical)
        {
            switch (Align)
            {
                case -1: table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft; break;//左对齐
                case 0: table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter; break;//水平居中
                case 1: table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight; break;//右对齐
            }
            switch (Vertical)
            {
                case -1: table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalTop; break;//顶端对齐
                case 0: table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; break;//垂直居中
                case 1: table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom; break;//底端对齐
            }
        }


        /// <summary>
        /// 设置表格字体
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fontName"></param>
        /// <param name="size"></param>
        public void SetFont_Table(Microsoft.Office.Interop.Word.Table table, string fontName, double size)
        {
            if (size != 0)
            {
                table.Range.Font.Size = Convert.ToSingle(size);
            }
            if (fontName != "")
            {
                table.Range.Font.Name = fontName;
            }
        }

        //是否使用边框,n表格的序号,use是或否
        /// <summary>
        /// 是否使用边框
        /// </summary>
        /// <param name="n">表格的序号</param>
        /// <param name="use">是或否</param>
        public void UseBorder(int n, bool use)
        {
            if (use)
            {
                wordDoc.Content.Tables[n].Borders.Enable = 1;  //允许有边框，默认没有边框(为0时报错，1为实线边框，2、3为虚线边框，以后的数字没试过)
            }
            else
            {
                wordDoc.Content.Tables[n].Borders.Enable = 2;  //允许有边框，默认没有边框(为0时报错，1为实线边框，2、3为虚线边框，以后的数字没试过)
            }
        }

        //给表格插入一行,n表格的序号从1开始记
        /// <summary>
        /// 给表格插入一行
        /// </summary>
        /// <param name="n">序号从1开始记</param>
        public void AddRow(int n)
        {
            object miss = System.Reflection.Missing.Value;
            wordDoc.Content.Tables[n].Rows.Add(ref miss);
        }

        /// <summary>
        /// 给表格添加一行
        /// </summary>
        /// <param name="table"></param>
        public void AddRow(Microsoft.Office.Interop.Word.Table table)
        {
            object miss = System.Reflection.Missing.Value;
            table.Rows.Add(ref miss);
        }
        /// <summary>
        /// 给表格插入rows行
        /// </summary>
        /// <param name="n">表格的序号</param>
        /// <param name="rows"></param>
        public void AddRow(int n, int rows)
        {
            object miss = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            for (int i = 0; i < rows; i++)
            {
                table.Rows.Add(ref miss);
            }
        }

        //给表格中单元格插入元素，table所在表格，row行号，column列号，value插入的元素
        /// <summary>
        /// 给表格中单元格插入元素
        /// </summary>
        /// <param name="table">所在表格</param>
        /// <param name="row">行号</param>
        /// <param name="column">列号</param>
        /// <param name="value">插入的元素</param>
        public void InsertCell(Microsoft.Office.Interop.Word.Table table, int row, int column, string value)
        {
            table.Cell(row, column).Range.Text = value;
        }

        //n表格的序号从1开始记，row行号，column列号，value插入的元素
        /// <summary>
        /// 给表格中单元格插入元素
        /// </summary>
        /// <param name="n">序号从1开始记</param>
        /// <param name="row">行号</param>
        /// <param name="column">列号</param>
        /// <param name="value">插入的元素</param>
        public void InsertCell(int n, int row, int column, string value)
        {
            wordDoc.Content.Tables[n].Cell(row, column).Range.Text = value;
        }
        /// <summary>
        /// 给表格插入一行数据
        /// </summary>
        /// <param name="n">序号</param>
        /// <param name="row">行号</param>
        /// <param name="columns">列数</param>
        /// <param name="values">插入的值</param>
        public void InsertCell(int n, int row, int columns, string[] values)
        {
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            for (int i = 0; i < columns; i++)
            {
                table.Cell(row, i + 1).Range.Text = values[i];
                // table.Cell(row, i + 1).Range.Font.Color 设置字体颜色
            }
        }
        /// <summary>
        /// 按照格式插入表格
        /// </summary>
        /// <param name="n"></param>
        /// <param name="row"></param>
        /// <param name="columns"></param>
        /// <param name="values"></param>
        /// <param name="pFontSize"></param>
        /// <param name="pFontBold"></param>
        public void InsertCellFormat(int n, int row, int columns, string[] values, int pFontSize, int pFontBold)
        {
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            //  table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            try
            {
                for (int i = 0; i < columns; i++)
                {
                    //table.Cell(row, i + 1).Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //table.Cell(row, i + 1).Range.Font.Size = pFontSize;
                    //table.Cell(row, i + 1).Range.Font.Bold = pFontBold;
                    table.Cell(row, i + 1).Range.Text = values[i];

                    // table.Cell(row, i + 1).Range.Font.Color 设置字体颜色



                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "提示！");
            }

        }

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="picturePath">图片路径</param>
        /// <param name="width">宽度</param>
        /// <param name="hight">高度</param>
        public void InsertPicture(string bookmark, string picturePath, float width, float hight)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            Object linkToFile = false;       //图片是否为外部链接
            Object saveWithDocument = true;  //图片是否随文档一起保存 
            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range;//图片插入位置
            wordDoc.InlineShapes.AddPicture(picturePath, ref linkToFile, ref saveWithDocument, ref range);
            wordDoc.Application.ActiveDocument.InlineShapes[1].Width = width;   //设置图片宽度
            wordDoc.Application.ActiveDocument.InlineShapes[1].Height = hight;  //设置图片高度
        }

        /// <summary>
        /// 插入一段文字
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="text">文字</param>
        public void InsertText(string bookmark, string text)
        {
            object oStart = bookmark;
            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range;
            Paragraph wp = wordDoc.Content.Paragraphs.Add(ref range);
            wp.Format.SpaceBefore = 6;
            wp.Range.Text = text;
            wp.Format.SpaceAfter = 24;
            wp.Range.InsertParagraphAfter();
            wordDoc.Paragraphs.Last.Range.Text = "\n";
        }
        public void InsertText2(string bookmark, string text)
        {
            object oStart = bookmark;
            Range range = wordDoc.Bookmarks.get_Item(ref oStart).Range;
            range.Text = text;
            //  Paragraph wp = wordDoc.Content.Paragraphs.Add(ref range);
            ////  wp.Format.SpaceBefore = 6;
            //  wp.Range.Text = text;
            ////  wp.Format.SpaceAfter = 24;
            // wp.Range.InsertParagraphAfter();
            //wordDoc.Paragraphs.Last.Range.Text = "\n";
        }
        /// <summary>
        /// 杀掉winword.exe进程
        /// </summary>
        public void killWinWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                bool b = process.MainWindowTitle == "";
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                }
            }
        }
    }
}
