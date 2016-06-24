
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

namespace Blog.IDAL
{
    
    ///
    //Blogentrie的描述
    ///
    public interface IBlogentrie
    {
          int GetMaxBlogID();
          BlogentrieEntity SelectBlogentrieByID(int t_blog_id);       
        //根据主键查询整个表
          IList<BlogentrieEntity> GetAllBlogentrie();      
        //根据外键进行查询
          IList<BlogentrieEntity> GetAllBlogentrieByauthor_id(int t_author_id);
          IList<BlogentrieEntity> GetAllBlogentrieByblogtype_id(int t_blogtype_id);
        //插入操作
          int InsertBlogentrie(BlogentrieEntity t_Blogentrie);       
        //修改操作
          int UpdateBlogentrie(BlogentrieEntity t_Blogentrie);
        //删除操作
          int DeleteBlogentrie(int t_blog_id);
       
    }
}