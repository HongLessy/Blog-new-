using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Configuration;


namespace Blog.DALFactory
{
    public static class DataAccess
    {
        private static string path = ConfigurationManager.AppSettings["WebDAL"];

        public static Blog.IDAL.IAuthor CreateAuthor()
        {
            return (Blog.IDAL.IAuthor)Assembly.Load(path).CreateInstance(path + ".Author");
        }

        public static Blog.IDAL.IBlogentrie CreateBlogentrie()
        {
            return (Blog.IDAL.IBlogentrie)Assembly.Load(path).CreateInstance(path + ".Blogentrie");
        }

        public static Blog.IDAL.IBlogtype CreateBlogtype()
        {
            return (Blog.IDAL.IBlogtype)Assembly.Load(path).CreateInstance(path + ".Blogtype");
        }

        public static Blog.IDAL.IComment CreateComment()
        {
            return (Blog.IDAL.IComment)Assembly.Load(path).CreateInstance(path + ".Comment");
        }

        public static Blog.IDAL.IFile CreateFile()
        {
            return (Blog.IDAL.IFile)Assembly.Load(path).CreateInstance(path + ".File");
        }

        public static Blog.IDAL.ILog CreateLog()
        {
            return (Blog.IDAL.ILog)Assembly.Load(path).CreateInstance(path + ".Log");
        }

        public static Blog.IDAL.IModel CreateModel()
        {
            return (Blog.IDAL.IModel)Assembly.Load(path).CreateInstance(path + ".Model");
        }

        public static Blog.IDAL.IPersonsetting CreatePersonsetting()
        {
            return (Blog.IDAL.IPersonsetting)Assembly.Load(path).CreateInstance(path + ".Personsetting");
        }

        public static Blog.IDAL.IRole CreateRole()
        {
            return (Blog.IDAL.IRole)Assembly.Load(path).CreateInstance(path + ".Role");
        }
        public static Blog.IDAL.ITag CreateTag()
        {
            return (Blog.IDAL.ITag)Assembly.Load(path).CreateInstance(path + ".Tag");
        }
        public static Blog.IDAL.IBlog_Tag CreateBlog_Tag()
        {
            return (Blog.IDAL.IBlog_Tag)Assembly.Load(path).CreateInstance(path + ".Blog_Tag");
        }
    }
}
