
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
    //Blog_Tag的描述
    ///
    public static class Blog_TagManager
    {
        private static Blog.IDAL.IBlog_Tag dal=Blog.DALFactory.DataAccess.CreateBlog_Tag();
        
        public static Blog_TagEntity SelectBlog_TagByID(int t_blog_tag_id)
        {
            Blog_TagEntity temp=null;
            try
            {
                temp=dal.SelectBlog_TagByID(t_blog_tag_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        //根据主键查询整个表
        public static IList<Blog_TagEntity> GetAllBlog_Tag()
        {
            IList<Blog_TagEntity> temp=null;
            try
            {
                temp=GetAllBlog_Tag();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        
        //根据外键进行查询
        public static IList<Blog_TagEntity> GetAllBlog_TagBytag_id(int t_tag_id)
        {
           IList<Blog_TagEntity> temp=null;
           try
            {
                temp=GetAllBlog_TagBytag_id(t_tag_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        

        
        //插入操作
        public static int InsertBlog_Tag(Blog_TagEntity t_Blog_Tag)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=InsertBlog_Tag(t_Blog_Tag);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return i;
        }
        
        public static int UpdateBlog_Tag(Blog_TagEntity t_Blog_Tag)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=UpdateBlog_Tag(t_Blog_Tag);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
        
        public static int DeleteBlog_Tag(int t_blog_tag_id)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=DeleteBlog_Tag(t_blog_tag_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
    }
}