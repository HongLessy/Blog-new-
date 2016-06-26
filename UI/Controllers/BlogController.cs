using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Model;
using Blog.BLL;
using System.Xml;
using System.Text;

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
            var model = (from blogentry in blogEntries orderby blogentry.Datecreated descending select blogentry).Skip(n).Take(pageSize).ToList();
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
        public ActionResult BlogArticles(int page)
        {
            int authorID = (int)Session["visitor"];
            var blogs = BlogentrieManager.GetAllBlogentrieByauthor_id(authorID);
            var articles = blogs.Select(p => p).Where(p => p.Type == "文章").Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewData["page"] = page;
            ApplicationSetting();
            return View(articles);
            
        }
        public ActionResult BlogByMonth(int year,int month,int page)
        {
            int authorID = (int)Session["visitor"];
            var blogEntries = BlogentrieManager.GetAllBlogentrieByauthor_id(authorID);
            int count = blogEntries.Count;
            if (page <= 0) page = 1;
            if (page * pageSize > count) page = page - 1;

            ViewData["page"] = page;
            ViewData["Year"] = year;
            ViewData["Month"] = month;


            var model = blogEntries.Select(p => p).Where(p => (p.Datecreated.Year == year) && (p.Datecreated.Month == month)).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ApplicationSetting();

            return View(model);
        }
        public ActionResult RSSBlogs()
        {

            int authorID = (int)Session["visitor"];
            Response.Clear();

            Response.ContentType = "text/xml";
            XmlTextWriter xtw = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);

            xtw.WriteStartDocument();

            xtw.WriteStartElement("rss");
            xtw.WriteAttributeString("version", "2.0");

            xtw.WriteStartElement("channel");
            PersonsettingEntity entity = PersonsettingManager.GetAllPersonsettingByauthor_id(authorID).First();
            xtw.WriteAttributeString("title", entity.Blog_path + ":::::Entry Feed:::::");
            xtw.WriteAttributeString("link", entity.Blog_path + "/Blog/Index?id=" + authorID + "&page=1");
            xtw.WriteAttributeString("description", "来自" + entity.Blog_path + "的博客");
            xtw.WriteAttributeString("copyright", "it belongs to www.HonLessy.vicp.io");

            var Blogs = BlogentrieManager.GetAllBlogentrieByauthor_id(authorID);
            var entries = Blogs.Select(p => p).Where(p => p.Type == "随笔").ToList();

            foreach (var entry in entries)
            {
                xtw.WriteStartElement("item");
                xtw.WriteAttributeString("title", entry.Title);
                xtw.WriteAttributeString("description", entry.Description);
                xtw.WriteAttributeString("link", entity.Blog_path + "/BlogEntry.aspx?page=" + entry.Blog_id);
                xtw.WriteAttributeString("publishDate", entry.Datepublished.ToString());

                xtw.WriteEndElement();
            }

            xtw.WriteEndElement();
            xtw.WriteEndElement();
            xtw.WriteEndDocument();

            xtw.Flush();
            xtw.Close();
            Response.End();

            return View();
        }
        public ActionResult RSSArticles()
        {

            int authorID = (int)Session["visitor"];
            Response.Clear();

            Response.ContentType = "text/xml";
            XmlTextWriter xtw = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);

            xtw.WriteStartDocument();

            xtw.WriteStartElement("rss");
            xtw.WriteAttributeString("version", "2.0");

            xtw.WriteStartElement("channel");
            PersonsettingEntity entity = PersonsettingManager.GetAllPersonsettingByauthor_id(authorID).First();
            xtw.WriteAttributeString("title", entity.Blog_path + ":::::Articles Feed:::::");
            xtw.WriteAttributeString("link", entity.Blog_path + "Blog/Index?id=" + authorID + "&page=1");
            xtw.WriteAttributeString("description", "来自" + entity.Blog_path + "的博客");
            xtw.WriteAttributeString("copyright", "it belongs to www.HonLessy.vicp.io");

            var Blogs = BlogentrieManager.GetAllBlogentrieByauthor_id(authorID);
            var entries = Blogs.Select(p => p).Where(p => p.Type == "文章").ToList();

            foreach (var entry in entries)
            {
                xtw.WriteStartElement("item");
                xtw.WriteAttributeString("title", entry.Title);
                xtw.WriteAttributeString("description", entry.Description);
                xtw.WriteAttributeString("link", entity.Blog_path + "BlogEntry.aspx?page=" + entry.Blog_id);
                xtw.WriteAttributeString("publishDate", entry.Datepublished.ToString());

                xtw.WriteEndElement();
            }

            xtw.WriteEndElement();
            xtw.WriteEndElement();
            xtw.WriteEndDocument();

            xtw.Flush();
            xtw.Close();
            Response.End();

            return View();
        }
        public ActionResult RSSComments()
        {

            int authorID = (int)Session["visitor"];
            Response.Clear();

            Response.ContentType = "text/xml";
            XmlTextWriter xtw = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);

            xtw.WriteStartDocument();

            xtw.WriteStartElement("rss");
            xtw.WriteAttributeString("version", "2.0");

            xtw.WriteStartElement("channel");
            PersonsettingEntity entity = PersonsettingManager.GetAllPersonsettingByauthor_id(authorID).First();
            xtw.WriteAttributeString("title", entity.Blog_path + ":::::Articles Feed:::::");
            xtw.WriteAttributeString("link", entity.Blog_path + "Blog/Index?id=" + authorID + "&page=1");
            xtw.WriteAttributeString("description", "来自" + entity.Blog_path + "的博客");
            xtw.WriteAttributeString("copyright", "it belongs to www.HonLessy.vicp.io");

            var blogs = BlogentrieManager.GetAllBlogentrieByauthor_id(authorID).ToList();
            var blogIDs = blogs.Select(p => p.Blog_id).ToList();
            var comments = CommentManager.GetAllComment().Select(p=>p).Where(p=>blogIDs.Contains(p.Blog_id));


            foreach (var comment in comments)
            {
                xtw.WriteStartElement("item");
                xtw.WriteAttributeString("title", comment.Author);
                xtw.WriteAttributeString("description", "from" +comment.Author);
                xtw.WriteAttributeString("link", entity.Blog_path + "BlogEntry.aspx?page=" + comment.Blog_id);
                xtw.WriteAttributeString("publishDate", comment.Datecreated.ToString());

                xtw.WriteEndElement();
            }

            xtw.WriteEndElement();
            xtw.WriteEndElement();
            xtw.WriteEndDocument();

            xtw.Flush();
            xtw.Close();
            Response.End();

            return View();
        }
        public ActionResult BlogEntry(int page)
        {
            BlogentrieEntity be = BlogentrieManager.SelectBlogentrieByID(page);

            ApplicationSetting();
            return View(be);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddComment(int id,string commentAuthor,string commentText)
        { 
            CommentEntity ce = new CommentEntity();
            ce.Blog_id = id;
            ce.Body = commentText;
            ce.Author = commentAuthor;
            ce.Datecreated = DateTime.Now;
            ce.Datemodified = DateTime.Now;
            ce.Islock = "n";
            ce.Ip = "137.45.0.0";
            CommentManager.InsertComment(ce); 



            ApplicationSetting();
            return RedirectToAction("BlogEntry",new{page  = id});
        }
    }       
}
