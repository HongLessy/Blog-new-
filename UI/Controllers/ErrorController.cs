using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace UI.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        [HandleError]
        [OutputCache(Location=OutputCacheLocation.None)]
        public ActionResult Index(string errorInfo)
        {
            ViewData["Title"] = "0.0出错了->程序员用意念摧毁了你的电脑00.00";
            ViewData["Desctiption"] = errorInfo;
            return View();
        }
        public ActionResult HttpErrorFor404(string errorInfo)
        {
            ViewData["Title"] = "0.0出错了->页面被程序员删除了！00.00（404） ";
            ViewData["Desctiption"] = errorInfo;
            return View("Index");
        }
        public ActionResult HttpErrorFor500(string errorInfo)
        {
            ViewData["Title"] = "0.0出错了->服务器被程序员不小心关掉了！00.00（500） ";
            ViewData["Desctiption"] = errorInfo;
            return View("Index");
        }
        public ActionResult Commom(string errorInfo)
        {
            ViewData["Title"] = "未知错误！都怪程序员！瞎编代码 ";
            ViewData["Desctiption"] = errorInfo;
            return View("Index");
        }
    }
}
