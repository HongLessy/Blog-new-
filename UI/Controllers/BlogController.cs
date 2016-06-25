using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Model;
using Blog.BLL;

namespace UI.Controllers
{
    public class BlogController : Controller
    {
        int pageSize = 3;
        //
        // GET: /Blog/

        public ActionResult Index(int page,int authorID)
        {
            Session["visitor"] = authorID;
            var blogEntries = BlogentrieManager.GetAllBlogentrieByauthor_id(authorID);
            int count = blogEntries.Count;
            if (page <= 0) page = 1;
            if (page * pageSize > count) page = page - 1;

            ViewData["page"] = page;
            int n = (page - 1) * pageSize;
            var model = (from blogentry in blogEntries orderby blogentry.Datecreated descending select blogentry).Skip((page - 1) * pageSize);

            ApplicationSetting();

            return View(model);
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
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult BlogByTag(int id,int page)
        {
            int authorID = (int)Session["visitor"]; 
            var blogEntries = BlogentrieManager.GetAllBlogentrieByauthor_id(authorID);
            int count = blogEntries.Count;
            if (page <= 0) page = 1;
            if (page * pageSize > count) page = page - 1;

            ViewData["page"] = page;
            ViewData["TagName"] = TagManager.SelectTagByID(id).TagName;
            ViewData["TagId"] = id;

            var blog_tags = Blog_TagManager.GetAllBlog_TagBytag_id(id);
            var blogIDs = blog_tags.Select(p=>p.Blog_id).ToList();
            var model = blogEntries.Select(p => p).Where(p => blogIDs.Contains(p.Blog_id)).ToList();

            ApplicationSetting();
            return View(model);
        }
    }       
}
