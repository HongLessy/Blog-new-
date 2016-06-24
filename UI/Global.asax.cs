using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Blog.BLL;
using Blog.Model;
using UI.Controllers;

namespace UI
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
        protected void Application_Error(object sender,EventArgs e)
        {
            AuthorEntity entity = (AuthorEntity)Session["userinfo"];

            LogEntity logentity = new LogEntity();
            if(entity==null)
            {
                logentity.Author_id=1;
            }
            else
            {
                logentity.Author_id=entity.Author_id;
            }
            logentity.Date = DateTime.Now;
            logentity.Opevent = Server.GetLastError().ToString();
            LogManager.InsertLog(logentity);


            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;
            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");

            if(httpException==null)
            {
                routeData.Values.Add("action", "Index");
            }
            else
            {
                if(httpException.GetHttpCode()==404)
                {
                    routeData.Values.Add("action", "HttpErrorFor404");
                }
                else if(httpException.GetHttpCode()==500)
                {
                    routeData.Values.Add("action", "HttpErrorFor500");
                }
                else
                {
                    routeData.Values.Add("action", "Commom");
                }
            }
            routeData.Values.Add("error", exception);
            Server.ClearError();


            IController errorController = new ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}