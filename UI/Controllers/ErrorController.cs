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
            ViewData["Title"] = "0.0出错了->可能是程序员用意念摧毁了你的电脑";
            ViewData["Desctiption"] = errorInfo;
            return View();
        }
        public ActionResult HttpErrorFor404(string errorInfo)
        {
            ViewData["Title"] = "0.0出错了->（404）页面被程序员当夜宵吃掉了！！ ";
            ViewData["Desctiption"] = errorInfo;
            return View("Index");
        }
        public ActionResult HttpErrorFor500(string errorInfo)
        {
            ViewData["Title"] = "0.0出错了->（500）服务器被程序员不小心关掉了！！ ";
            ViewData["Desctiption"] = errorInfo;
            return View("Index");
        }
        public ActionResult Commom(string errorInfo)
        {
            ViewData["Title"] = "未知错误！都怪程序员！瞎编代码！！扣一个月工资！ ";
            ViewData["Desctiption"] = errorInfo;
            return View("Index");
        }
    }
}
