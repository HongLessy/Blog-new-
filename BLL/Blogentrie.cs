
///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

using Blog.Model;
using Blog.DBUtility;
using Blog.IDAL;
using Blog.SqlServerDAL;
using Blog.AccessDAL;
using Blog.DALFactory;


namespace Blog.BLL
{
    
    ///
    //Blogentrie的描述
    ///
    public static class BlogentrieManager
    {
        private static Blog.IDAL.IBlogentrie dal=Blog.DALFactory.DataAccess.CreateBlogentrie();
        
        public static BlogentrieEntity SelectBlogentrieByID(int t_blog_id)
        {
            BlogentrieEntity temp=null;
            try
            {
                temp=dal.SelectBlogentrieByID(t_blog_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        //根据主键查询整个表
        public static IList<BlogentrieEntity> GetAllBlogentrie()
        {
            IList<BlogentrieEntity> temp=null;
            try
            {
                temp=dal.GetAllBlogentrie();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        
        //根据外键进行查询
        public static IList<BlogentrieEntity> GetAllBlogentrieByauthor_id(int t_author_id)
        {
           IList<BlogentrieEntity> temp=null;
           try
            {
                temp=dal.GetAllBlogentrieByauthor_id(t_author_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        public static IList<BlogentrieEntity> GetAllBlogentrieByblogtype_id(int t_blogtype_id)
        {
           IList<BlogentrieEntity> temp=null;
           try
            {
                temp=dal.GetAllBlogentrieByblogtype_id(t_blogtype_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        

        
        //插入操作
        public static int InsertBlogentrie(BlogentrieEntity t_Blogentrie)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=dal.InsertBlogentrie(t_Blogentrie);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return i;
        }
        
        public static int UpdateBlogentrie(BlogentrieEntity t_Blogentrie)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=dal.UpdateBlogentrie(t_Blogentrie);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
        
        public static int DeleteBlogentrie(int t_blog_id)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=dal.DeleteBlogentrie(t_blog_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
    }
}