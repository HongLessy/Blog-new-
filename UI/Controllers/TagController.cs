using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.BLL;
using Blog.Model;

namespace UI.Controllers
{
    public class TagController : Controller
    {
        //
        // GET: /Tag/
            
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TagCloud()
        {
            int authorID = (int)Session["visitor"];
            var tags = TagManager.GetAllTag().Select(p => p).Where(p => p.Author_id == authorID);


            ApplicationSetting();
            return View(tags);
        }
        public void ApplicationSetting()
        {
            int authorID = (int)Session["visitor"];
            ViewData["Tags"] = TagManager.GetAllTag().Select(p => p).Where(p => p.Author_id == authorID);



            ViewData["Months"] = GetMonthsList(0, 10).Select(p => p);
        }
        public IList<Month> GetMonthsList(int startIndex, int pageSize)
        {
            int authorID = (int)Session["visitor"];
            var blogs = BlogentrieManager.GetAllBlogentrieByauthor_id(authorID).Select(p => p).Where(p => p.Markprivate == "n");
            var query = (from blog in blogs select new { blog.Datecreated.Year, blog.Datecreated.Month }).Distinct().Skip(startIndex).Take(pageSize).OrderByDescending(p => p.Month);
            IList<Month> months = new List<Month>();

            Month m = null;
            foreach (var t in query)
            {
                m = new Month(t.Year, t.Month);
                m.number = blogs.Select(p => p).Where(p => (p.Datecreated.Year == t.Year) && (p.Datecreated.Month == t.Month)).Count();
                months.Add(m);

            }
            return months;
        }

    }
}
