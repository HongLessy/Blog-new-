
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

namespace Blog.SqlServerDAL
{
    
    ///
    //Comment的描述
    ///
    public class Comment:IComment
    {
    
        public  CommentEntity SelectCommentByID(int t_comment_id)
        {
            CommentEntity t_Comment= new CommentEntity();
            SqlDataReader sdr=null;
            using(sdr=SqlDBHelp.GetReader("select * from Comments where comment_id="+t_comment_id))
            {
                if(sdr.Read())
                {
                    t_Comment.Comment_id=(int)sdr.GetValue(0);
                    t_Comment.Author=(string)sdr.GetValue(1);
                    t_Comment.Blog_id=(int)sdr.GetValue(2);
                    t_Comment.Ip=(string)sdr.GetValue(3);
                    t_Comment.Datecreated=(DateTime)sdr.GetValue(4);
                    t_Comment.Datemodified=(DateTime)sdr.GetValue(5);
                    t_Comment.Body=(string)sdr.GetValue(6);
                    t_Comment.Islock=(string)sdr.GetValue(7);
                }
            }
            sdr.Close(); 
            return t_Comment;
        }
        
        //根据主键查询整个表
        public IList<CommentEntity> GetAllComment()
        {
            IList<CommentEntity> t_Comments = new List<CommentEntity>();
            SqlDataReader sdr = null;
            using(sdr=SqlDBHelp.GetReader("select * from Comments"))
            {
                while(sdr.Read())
                {
                    CommentEntity t_Comment= new CommentEntity();
                    t_Comment.Comment_id=(int)sdr.GetValue(0);                  
                    t_Comment.Author=(string)sdr.GetValue(1);                  
                    t_Comment.Blog_id=(int)sdr.GetValue(2);                  
                    t_Comment.Ip=(string)sdr.GetValue(3);                  
                    t_Comment.Datecreated=(DateTime)sdr.GetValue(4);                  
                    t_Comment.Datemodified=(DateTime)sdr.GetValue(5);                  
                    t_Comment.Body=(string)sdr.GetValue(6);                  
                    t_Comment.Islock=(string)sdr.GetValue(7);                  
                    t_Comments.Add(t_Comment);
                }
                sdr.Close();
            }
            return t_Comments;
        }
        
        
        //根据外键进行查询
        public IList<CommentEntity> GetAllCommentByblog_id(int t_blog_id)
        {
           IList<CommentEntity> t_Comments = new List<CommentEntity>();
           SqlDataReader sdr = null;
           using(sdr=SqlDBHelp.GetReader("select * from Comments where blog_id="+t_blog_id))
           {
              while(sdr.Read())
                {
                    CommentEntity t_Comment= new CommentEntity();
                    t_Comment.Comment_id=(int)sdr.GetValue(0);                    
                    t_Comment.Author=(string)sdr.GetValue(1);                    
                    t_Comment.Blog_id=(int)sdr.GetValue(2);                    
                    t_Comment.Ip=(string)sdr.GetValue(3);                    
                    t_Comment.Datecreated=(DateTime)sdr.GetValue(4);                    
                    t_Comment.Datemodified=(DateTime)sdr.GetValue(5);                    
                    t_Comment.Body=(string)sdr.GetValue(6);                    
                    t_Comment.Islock=(string)sdr.GetValue(7);                    
                    t_Comments.Add(t_Comment);
                }
                sdr.Close();
            }
            return t_Comments;
        }
        

        
        //插入操作
        public  int InsertComment(CommentEntity t_Comment)
        {
          //定义插入数据的参数数组
              SqlParameter[] p=new SqlParameter[]{
              new SqlParameter("@Comment_id",t_Comment.Comment_id),
              new SqlParameter("@Author",t_Comment.Author),
              new SqlParameter("@Blog_id",t_Comment.Blog_id),
              new SqlParameter("@Ip",t_Comment.Ip),
              new SqlParameter("@Datecreated",t_Comment.Datecreated),
              new SqlParameter("@Datemodified",t_Comment.Datemodified),
              new SqlParameter("@Body",t_Comment.Body),
              new SqlParameter("@Islock",t_Comment.Islock)
           };
           int i=SqlDBHelp.GetExecute("insert into Comments values (@Comment_id,@Author,@Blog_id,@Ip,@Datecreated,@Datemodified,@Body,@Islock)", p) ;
           return i;
        }
        
        public  int UpdateComment(CommentEntity t_Comment)
        {
            SqlParameter[] p=new SqlParameter[]{
            new SqlParameter("@Comment_id",t_Comment.Comment_id),
            new SqlParameter("@Author",t_Comment.Author),
            new SqlParameter("@Blog_id",t_Comment.Blog_id),
            new SqlParameter("@Ip",t_Comment.Ip),
            new SqlParameter("@Datecreated",t_Comment.Datecreated),
            new SqlParameter("@Datemodified",t_Comment.Datemodified),
            new SqlParameter("@Body",t_Comment.Body),
            new SqlParameter("@Islock",t_Comment.Islock)
            };
            int i=SqlDBHelp.GetExecute("update Comments set comment_id=@Comment_id,author=@Author,ip=@Ip,datecreated=@Datecreated,datemodified=@Datemodified,body=@Body,islock=@Islock where comment_id=@Comment_id", p) ;
            return i;
        }
        
        public int DeleteComment(int t_comment_id)
        {
            int i=SqlDBHelp.GetExecute("delete from Comments where comment_id="+t_comment_id);
			return i;
        }
    }
}