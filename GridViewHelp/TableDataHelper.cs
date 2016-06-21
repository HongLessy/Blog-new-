using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.Mvc.Html;
using System.Web.Routing;





using System.IO;

namespace GridViewHelper
{
    /// <summary>
    /// 拓展方法，提供数据显示的控制
    /// </summary>
    public static class TableDataHelper
    {
        public static string TableDataGridView<T>(this HtmlHelper helper)
        {
            return TableDataGridView<T>(helper, null, null, new TableDataOption());
        }

        public static string TableDataGridView<T>(this HtmlHelper helper, object data)
        {
            return TableDataGridView<T>(helper, data, null, new TableDataOption());
        }
        /// <summary>
        /// HtmlHelper的拓展方法，根据提供的数据源实现数据的表格显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <param name="data"></param>
        /// <param name="columns"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string TableDataGridView<T>(this HtmlHelper helper, object data, string[] columns, TableDataOption options)
        {
            //获取数据源数据
            var items = (IEnumerable<T>)data;
            if (items == null)
            {
                items = (IEnumerable<T>)helper.ViewData.Model;
            }
            //获取所有的列集合
            if (columns == null)
            {
                columns=typeof(T).GetProperties().Select(p => p.Name).ToArray();
            }

            //获取数据输出的文本对象
            var writer = new HtmlTextWriter(new StringWriter());

            //开始表格的生成
            //<table>
            writer.RenderBeginTag(HtmlTextWriterTag.Table);

            //
            //表格头<th>
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            //输出表格头
            RenderHeader(helper,writer,columns,options);
            //</th>
            writer.RenderEndTag();

            string identityColumnName=((TableDataPagedList<T>)items).IdentityColumnName;
            //
            //表格中的数据主体
            //<tbody>
            writer.RenderBeginTag(HtmlTextWriterTag.Tbody);
            //显示每一行数据
            foreach (var item in items)
            {
                RenderRow<T>(helper, writer, columns, item, identityColumnName,options);
            }
            //显示分页部分数据
            RenderPagerRow<T>(helper, writer, (TableDataPagedList<T>)items, columns.Count());
            //</tbody>
            writer.RenderEndTag();


            //</table>
            writer.RenderEndTag();

            return writer.InnerWriter.ToString();
        }

        //输出控制分页部分
        private static void RenderPagerRow<T>(HtmlHelper helper, HtmlTextWriter writer, TableDataPagedList<T> items, int columnCount)
        {
            int nrOfPagesToDisplay = 10;

            //如果仅一页数据，不显示分页
            if (items.TotalPageCount == 1) return;

            //<tr>
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.AddAttribute(HtmlTextWriterAttribute.Colspan,columnCount.ToString());

            //<td>        
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            var currentAction = helper.ViewContext.RouteData.Values["action"].ToString();

            //生成数字页码
            //不是第一页
            if (items.PageIndex >= 1)
            {
                var linkText = "<<<";
                
                var link = helper.ActionLink(linkText, currentAction, new { page=items.PageIndex,sort=items.SortExpression});
                writer.Write(link+"&nbsp;");
            }

            int start = 0;
            int end = items.TotalPageCount;
            //比较总页数与最大显示页数的关系
            if (items.TotalPageCount > nrOfPagesToDisplay)
            {
                int middle = (int)Math.Ceiling(nrOfPagesToDisplay / 2d) - 1;
                int below = items.PageIndex - middle;
                int above = items.PageIndex + middle;
                if (below < 4)
                {
                    above = nrOfPagesToDisplay;
                    below = 0;
                }
                else if (above + 4 > items.TotalPageCount)
                {
                    above = items.TotalPageCount;
                    below = items.TotalPageCount - nrOfPagesToDisplay;
                }
                start = below;
                end = above;
            }

            if (start > 3)
            {
                var linkText = "1";
                var link = helper.ActionLink(linkText, currentAction, new { page = 1, sort = items.SortExpression });
                writer.Write(link + "&nbsp;");

                linkText = "2";
                link = helper.ActionLink(linkText, currentAction, new { page = 2, sort = items.SortExpression });
                writer.Write(link + "&nbsp;");

                writer.Write("...");
            }

            for (var i = start; i < end; i++)
            {
                if (i == items.PageIndex)
                {
                    writer.Write("<strong>" + (i + 1) + "</strong>&nbsp;");
                }
                else
                {
                    var linkText = i+1+"";
                    var link = helper.ActionLink(linkText, currentAction, new { page = i+1, sort = items.SortExpression });
                    writer.Write(link + "&nbsp;");
                }
            }

            if (end < items.TotalPageCount-3)
            {
                writer.Write("...");

                var linkText = items.TotalPageCount-1+"";
                var link = helper.ActionLink(linkText, currentAction, new { page = items.TotalPageCount-1, sort = items.SortExpression });
                writer.Write(link + "&nbsp;");

                linkText = items.TotalPageCount+"" ;
                link = helper.ActionLink(linkText, currentAction, new { page = items.TotalPageCount , sort = items.SortExpression });
                writer.Write(link + "&nbsp;");
            }

            if (items.PageIndex <= items.TotalPageCount - 2)
            {
                var linkText = ">>>";
                var link = helper.ActionLink(linkText, currentAction, new { page = items.PageIndex+2, sort = items.SortExpression });
                writer.Write(link + "&nbsp;");
            }

            //</td>
            writer.RenderEndTag();
            //</tr>
            writer.RenderEndTag();

        }

        //输出一行数据部分
        private static void RenderRow<T>(HtmlHelper helper, HtmlTextWriter writer, string[] columns, T item, string identityColumnName, TableDataOption options)
        {
            //<tr>
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);

            //<td>value</td>
            //<td>value</td>
            foreach (var columnName in columns)
            {
                //<td>
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                var value = typeof(T).GetProperty(columnName).GetValue(item, null) ?? string.Empty;
                writer.Write(helper.Encode(value.ToString()));
                //</td>
                writer.RenderEndTag();
            }
            //<td><a href="action?id=identityColumnName">编辑</td>
            if (options.ShowDeleteButton || options.ShowEditButton)
            {
                var identityValue = typeof(T).GetProperty(identityColumnName).GetValue(item, null);
                //<td>
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                if (options.ShowEditButton)
                {
                    var link = helper.ActionLink(options.EditButtonText, options.EditAction, new { id = identityValue });
                    writer.Write(link);
                    writer.Write(" ");
                }
                if (options.ShowDeleteButton)
                {
                    var link = helper.ActionLink(options.DeleteButtonText, options.DeleteAction, new { id = identityValue }, new { OnClick="return confirm('你确认删除吗？');"});
                    writer.Write(link);
                    writer.Write(" ");
                }
                //</td>
                writer.RenderEndTag();
            }


            //</tr>
            writer.RenderEndTag();

        }      

        //输出表格头部分
        public static void  RenderHeader(HtmlHelper helper, HtmlTextWriter writer, string[] columns, TableDataOption options)
        {
            //<tr>
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);

            int i = 0;
            foreach (string columnName in columns)
            {
                //<th>
                writer.RenderBeginTag(HtmlTextWriterTag.Th);
                var currentAction = helper.ViewContext.RouteData.Values["action"].ToString();
                string link = null;
                if (options.Columns == null)
                {
                    link = helper.ActionLink(columnName, currentAction, new { sort = columnName }).ToString();
                }
                else
                {
                    link = helper.ActionLink(options.Columns[i], currentAction, new { sort = columnName }).ToString() ;
                    i++;
                }
                //<a href="/currentAction?sort=columnName">options.Columns[i]</a>
                writer.Write(link);
                //</th>
                writer.RenderEndTag();

            }

            //判断是否显示 编辑和删除按钮
            if (options.ShowEditButton || options.ShowDeleteButton)
            {
                //<th>
                writer.RenderBeginTag(HtmlTextWriterTag.Th);
                writer.Write(helper.Encode(""));
                //</th>
                writer.RenderEndTag();
            }

            //</tr>
            writer.RenderEndTag();
        }
      
    }
}
