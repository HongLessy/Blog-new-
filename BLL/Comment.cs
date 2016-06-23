
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
    //Comment的描述
    ///
    public static class CommentManager
    {
        private static Blog.IDAL.IComment dal=Blog.DALFactory.DataAccess.CreateComment();
        
        public static CommentEntity SelectCommentByID(int t_comment_id)
        {
            CommentEntity temp=null;
            try
            {
                temp=dal.SelectCommentByID(t_comment_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        //根据主键查询整个表
        public static IList<CommentEntity> GetAllComment()
        {
            IList<CommentEntity> temp=null;
            try
            {
                temp = dal.GetAllComment();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        
        //根据外键进行查询
        public static IList<CommentEntity> GetAllCommentByblog_id(int t_blog_id)
        {
           IList<CommentEntity> temp=null;
           try
            {
                temp = dal.GetAllCommentByblog_id(t_blog_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        

        
        //插入操作
        public static int InsertComment(CommentEntity t_Comment)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.InsertComment(t_Comment);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return i;
        }
        
        public static int UpdateComment(CommentEntity t_Comment)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.UpdateComment(t_Comment);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
        
        public static int DeleteComment(int t_comment_id)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.DeleteComment(t_comment_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
    }
}