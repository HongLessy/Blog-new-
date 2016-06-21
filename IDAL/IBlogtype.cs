
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
    //Blogtype的描述
    ///
    public interface IBlogtype
    {
          BlogtypeEntity SelectBlogtypeByID(int t_blogtype_id);       
        //根据主键查询整个表
          IList<BlogtypeEntity> GetAllBlogtype();      
        //根据外键进行查询
          IList<BlogtypeEntity> GetAllBlogtypeByauthor_id(int t_author_id);
        //插入操作
          int InsertBlogtype(BlogtypeEntity t_Blogtype);       
        //修改操作
          int UpdateBlogtype(BlogtypeEntity t_Blogtype);
        //删除操作
          int DeleteBlogtype(int t_blogtype_id);
       
    }
}