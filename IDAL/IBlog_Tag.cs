
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
    //Blog_Tag的描述
    ///
    public interface IBlog_Tag
    {
          Blog_TagEntity SelectBlog_TagByID(int t_blog_tag_id);       
        //根据主键查询整个表
          IList<Blog_TagEntity> GetAllBlog_Tag();      
        //根据外键进行查询
          IList<Blog_TagEntity> GetAllBlog_TagBytag_id(int t_tag_id);
        //插入操作
          int InsertBlog_Tag(Blog_TagEntity t_Blog_Tag);       
        //修改操作
          int UpdateBlog_Tag(Blog_TagEntity t_Blog_Tag);
        //删除操作
          int DeleteBlog_Tag(int t_blog_tag_id);

          Blog_TagEntity SelectBlog_TagByBlogID(int t_blog_id);
       
    }
}