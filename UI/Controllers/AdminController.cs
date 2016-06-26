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
        public string GetmodelName()
        {
            AuthorEntity entity = (AuthorEntity)Session["userinfo"];
            ModelEntity me = ModelManager.GetAllModel().Select(p => p).Where(p => p.Name == entity.Username).First();
            if(me==null)
            {
                return "Page";
            }
            else
            {
                return me.Path;
            }
            
        }
        //
        // GET: /Admin/

        public void ApplicationSetting()
        {
            AuthorEntity entity = (AuthorEntity)Session["userinfo"];
            int authorID = entity.Author_id;
            ViewData["Tags"] = TagManager.GetAllTag().Select(p => p).Where(p => p.Author_id == authorID);


        }
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

               
               return View("Index",GetmodelName(),model);
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
        public ActionResult AdminBlogCreate()
        {
            AuthorEntity entity = (AuthorEntity)Session["userinfo"];
           
            var model = TagManager.GetAllTag().ToList().Select(p => p).Where(p => p.Author_id == entity.Author_id).ToList();

            ViewData["tag"] = model;
            List<int> name = new List<int>();
            name.Add(entity.Author_id);
            ViewData["username"] = new SelectList(name);
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminBlogCreate(FormCollection form)
        {
            AuthorEntity entity = (AuthorEntity)Session["userinfo"];
            BlogentrieEntity blog = new BlogentrieEntity();
            blog.Author_id = entity.Author_id;
            blog.Title = form["title"].ToString();
            string[] selectedTags = form["TagCheckBox"].Split(new char[] { ',' });

            List<TagEntity> tags = TagManager.GetAllTag().Select(p => p).Where(p => p.Author_id == entity.Author_id).ToList();

            

            blog.Description = form["description"];
            blog.Type = form["type"];
            blog.Allowcomment = form["CommentCheckBox"].Contains("true") ? "y" : "n";
            blog.Markprivate = form["PrivateCheckBox"].Contains("true") ? "y" : "n";
            blog.Body = form["body"];
            blog.Datecreated = DateTime.Now;
            blog.Datemodified = DateTime.Now;
            blog.Datepublished = DateTime.Now;
            blog.Islock = "n";
            blog.Blogtype_id = 1;
            BlogentrieManager.InsertBlogentrie(blog);
            int maxBlogID = BlogentrieManager.GetMaxBlogID();
            for (int i = 0; i < selectedTags.Length; i++)
            {
                
                    
                    Blog_TagEntity bte = new Blog_TagEntity();
                    bte.Blog_id = maxBlogID;
                    bte.Tag_id = int.Parse(selectedTags[i]);
                    Blog_TagManager.InsertBlog_Tag(bte);
                
            }

            


            return RedirectToAction("index", new { page = "1" });
        }
        public ActionResult AdminBlogDelete(int id)
        {
            int i=BlogentrieManager.DeleteBlogentrie(id);
            return RedirectToAction("index", new { page = "1" });
        }
        public ActionResult AdminTags(string sort, int? page)
        {
            AuthorEntity entity = (AuthorEntity)Session["userinfo"];
            if (Session["userinfo"] == null)
            {
                return RedirectToAction("LogOn", "Account");
            }
            else
            {
                page = page ?? 0;
                if (page >= 1) page = page - 1;
              
                List<TagEntity> tags = TagManager.GetAllTag().Select(p => p).Where(p => p.Author_id == entity.Author_id).ToList();
                var model= tags.ToList().AsQueryable().ToPagedList(page, 5, "Tag_id", sort);
                return View(model);

            }
            

        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AdminTagEdit(int id)
        {
            AuthorEntity entity = (AuthorEntity)Session["userinfo"];
            TagEntity tagEntity =TagManager.SelectTagByID(id);
           
            return View(tagEntity);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminTagEdit(int id, FormCollection form)
        {
            TagEntity tagEntity = TagManager.SelectTagByID(id);
            tagEntity.TagName = form["tagname"];
            TagManager.UpdateTag(tagEntity);

            return RedirectToAction("AdminTags", new { page = "1" });
        }
        public ActionResult AdminTagDelete(int id)
        {
            int i = TagManager.DeleteTag(id);
            return RedirectToAction("AdminTags", new { page = "1" });
        }
        public ActionResult AdminTagCreate()
        {
            
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminTagCreate(FormCollection form)
        {

            if (Session["userinfo"] == null)
            {
                return RedirectToAction("LogOn", "Account");
            }
            else
            {
                TagEntity tagEntity = new TagEntity();
                AuthorEntity entity = (AuthorEntity)Session["userinfo"];
                tagEntity.Author_id = entity.Author_id;
                tagEntity.TagName = form["tagname"];

                TagManager.InsertTag(tagEntity);

                return RedirectToAction("AdminTags", new { page = "1" });
            }

            
        }
        public ActionResult AdminSetupEdit()
        {
            if (Session["userinfo"] == null)
            {
                return RedirectToAction("LogOn", "Account");
            }
            else
            {
                AuthorEntity entity = (AuthorEntity)Session["userinfo"];
                PersonsettingEntity model = PersonsettingManager.GetAllPersonsettingByauthor_id(entity.Author_id).First();
                return View(model);
            }
            
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminSetupEdit(FormCollection form)
        {
            if (Session["userinfo"] == null)
            {
                return RedirectToAction("LogOn", "Account");
            }
            else
            {
                AuthorEntity entity = (AuthorEntity)Session["userinfo"];
                PersonsettingEntity model = PersonsettingManager.GetAllPersonsettingByauthor_id(entity.Author_id).First();

                model.Blog_path = form["blog_path"];
                model.Blog_title = form["blog_title"];
                model.Description = form["description"];
                model.Rss_size = int.Parse(form["rss_size"]);
                model.Max_uploadfile = int.Parse(form["max_uploadfile"]);
                PersonsettingManager.UpdatePersonsetting(model);
                
                int modelid = int.Parse(form["model_id"].ToString());
                ModelEntity me = ModelManager.SelectModelByID(modelid);
                me.Path = form["changSkin"];
                ModelManager.UpdateModel(me);

                return RedirectToAction("index", new { page = "1" });
            }
        }
        public ActionResult AdminComments(string sort,int? page)
        {
            if (Session["userinfo"] == null)
            {
                return RedirectToAction("LogOn", "Account");
            }
            else
            {
                AuthorEntity entity = (AuthorEntity)Session["userinfo"];
                IList<CommentEntity> comments = CommentManager.GetAllCommentByAuthor_id(entity.Author_id);
                var model = comments.ToList().AsQueryable().ToPagedList(page, 5, "Comment_id", sort);
                return View(model);
            }
        }
        public ActionResult AdminCommentEdit(int id)
        {
            CommentEntity comment= CommentManager.SelectCommentByID(id);
            return View(comment);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminCommentEdit(int id,FormCollection form)
        {
            CommentEntity comment = CommentManager.SelectCommentByID(id);
            comment.Datecreated = DateTime.Now;
            //comment.Ip =Request
            comment.Body = form["body"];
            comment.Author = form["author"];

            CommentManager.UpdateComment(comment);
            return RedirectToAction("AdminComments");

        }
        public ActionResult AdminCommentDelete(int id)
        {
            int i = CommentManager.DeleteComment(id);
            return RedirectToAction("AdminComments");
        }
        public ActionResult AdminLog(string sort,int? page)
        {
            if (Session["userinfo"] == null)
            {
                return RedirectToAction("LogOn", "Account");
            }
            else
            {
                AuthorEntity entity = (AuthorEntity)Session["userinfo"];
                IList<LogEntity> logs = LogManager.GetAllLogByauthor_id(entity.Author_id).ToList();
                var model = logs.ToList().AsQueryable().ToPagedList(page, 5, "Id", sort);
                return View(model);
            }

        }
        public ActionResult AdminLogDelete(int id)
        {
            int i = LogManager.DeleteLog(id);
            return RedirectToAction("AdminLog");
        }

        public ActionResult AdminLogShow(int id)
        {
            LogEntity log = LogManager.SelectLogByID(id);
            return View(log);
        }
 
    }
}
