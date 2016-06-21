
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
    //author的描述
    ///
    public interface IAuthor
    {
          AuthorEntity SelectauthorByID(int t_author_id);       
        //根据主键查询整个表
          IList<AuthorEntity> GetAllauthor();
        //根据外键进行查询
          IList<AuthorEntity> GetAllauthorByrole_id(int t_role_id);
        //插入操作
          int Insertauthor(AuthorEntity t_author);       
        //修改操作
          int Updateauthor(AuthorEntity t_author);
        //删除操作
          int Deleteauthor(int t_author_id);
       
    }
}