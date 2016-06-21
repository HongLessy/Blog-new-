using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace UI.App_Code
{
    //这里是一个拓展方法
    //读取站点地图Web.sitemap，获取其中的网站逻辑
    //从而生成导航菜单
    public static class MenuHelp
    {
        public static string Menu(this HtmlHelper help)
        {
            var sb = new StringBuilder();

            //开始创建导航列表
            sb.Append("<ul>");

            //读取站点地图，生成导航节点
            var rootNodes = SiteMap.RootNode.ChildNodes;
            foreach (SiteMapNode n in rootNodes)
            {
                sb.AppendLine("<li>");

                //生成导航链接
                sb.AppendFormat("<a href='{0}'>{1}</a>",n.Url,n.Title);
                sb.AppendLine("</li>");
            }

            sb.Append("</ul>");

            return sb.ToString();
        }
    }
}
