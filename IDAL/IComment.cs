
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
    //Comment的描述
    ///
    public interface IComment
    {
          CommentEntity SelectCommentByID(int t_comment_id);       
        //根据主键查询整个表
          IList<CommentEntity> GetAllComment();      
        //根据外键进行查询
          IList<CommentEntity> GetAllCommentByblog_id(int t_blog_id);
          IList<CommentEntity> GetAllCommentByAuthor_id(int t_author_id);
        //插入操作
          int InsertComment(CommentEntity t_Comment);       
        //修改操作
          int UpdateComment(CommentEntity t_Comment);
        //删除操作
          int DeleteComment(int t_comment_id);
       
    }
}