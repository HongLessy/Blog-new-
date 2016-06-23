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

    }
}
