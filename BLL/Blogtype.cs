
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
    //Blogtype的描述
    ///
    public static class BlogtypeManager
    {
        private static Blog.IDAL.IBlogtype dal=Blog.DALFactory.DataAccess.CreateBlogtype();
        
        public static BlogtypeEntity SelectBlogtypeByID(int t_blogtype_id)
        {
            BlogtypeEntity temp=null;
            try
            {
                temp=dal.SelectBlogtypeByID(t_blogtype_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        //根据主键查询整个表
        public static IList<BlogtypeEntity> GetAllBlogtype()
        {
            IList<BlogtypeEntity> temp=null;
            try
            {
                temp=GetAllBlogtype();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        
        //根据外键进行查询
        public static IList<BlogtypeEntity> GetAllBlogtypeByauthor_id(int t_author_id)
        {
           IList<BlogtypeEntity> temp=null;
           try
            {
                temp=GetAllBlogtypeByauthor_id(t_author_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        

        
        //插入操作
        public static int InsertBlogtype(BlogtypeEntity t_Blogtype)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=InsertBlogtype(t_Blogtype);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return i;
        }
        
        public static int UpdateBlogtype(BlogtypeEntity t_Blogtype)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=UpdateBlogtype(t_Blogtype);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
        
        public static int DeleteBlogtype(int t_blogtype_id)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=DeleteBlogtype(t_blogtype_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
    }
}