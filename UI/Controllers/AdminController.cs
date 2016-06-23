using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Blog.Model;
using Blog.BLL;
using GridViewHelper;
namespace UI.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index(string sort,int? page)
        {
            if(Session["userinfo"]==null)
            {
                return RedirectToAction("LogOn", "Account");
            }
            else
            {
                page = page ?? 0;
                if (page >= 1) page = page - 1;
                List<BlogentrieEntity> model = new List<BlogentrieEntity>();
                AuthorEntity entity = (AuthorEntity)Session["userinfo"];
                IList<BlogentrieEntity> blogentries= BlogentrieManager.GetAllBlogentrieByauthor_id(entity.Author_id);
                //if(sort!=null)
                //{
                //    model = blogentries.ToList().AsQueryable().OrderBy(sort).ToPagedList(page,5,"blog_id",sort);
                //}
                //else
                //{
                    model = blogentries.ToList().AsQueryable().ToPagedList(page, 5, "Blog_id", sort);
                //}
               
                //
               
               
               return View(model);
            }
            
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AdminBlogEdit(int id)
        {
            AuthorEntity entity = (AuthorEntity)Session["userinfo"];
            BlogentrieEntity blog = BlogentrieManager.SelectBlogentrieByID(id);
            var model = TagManager.GetAllTag().ToList().Select(p => p).Where(p => p.Author_id==entity.Author_id).ToList();

            ViewData["tag"] = model;
            List<int> name = new List<int>();
            name.Add(entity.Author_id);
            ViewData["username"] =new SelectList(name);
            return View(blog);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminBlogEdit(int id, FormCollection form)
        {
            AuthorEntity entity = (AuthorEntity)Session["userinfo"];
            BlogentrieEntity blog = BlogentrieManager.SelectBlogentrieByID(id);
            blog.Title = form["title"].ToString();
            string[] selectedTags = form["TagCheckBox"].Split(new char[] { ',' });

            List<TagEntity> tags = TagManager.GetAllTag().Select(p => p).Where(p => p.Author_id == entity.Author_id).ToList();

            for (int i = 0; i < selectedTags.Length; i++)
            {
                if (selectedTags[i] == "true")
                {
                    blog.Blogtype_id = tags[i].Tag_id;
                }
            }

            blog.Description = form["description"];
            blog.Type = form["type"];
            blog.Allowcomment = form["CommentCheckBox"].Contains("true") ? "y" : "n";
            blog.Markprivate = form["PrivateCheckBox"].Contains("true") ? "y" : "n";
            blog.Body = form["body"];
            blog.Datemodified = DateTime.Now;

            BlogentrieManager.UpdateBlogentrie(blog);

            return RedirectToAction("index", new { page = "1" });
        }

    }
}
