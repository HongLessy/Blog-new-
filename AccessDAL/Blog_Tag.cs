﻿
///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System;

using Blog.Model;
using Blog.DBUtility;
using Blog.IDAL;

namespace Blog.AccessDAL
{
    
    ///
    //Blog_Tag的描述
    ///
    public class Blog_Tag:IBlog_Tag
    {
    
        public Blog_TagEntity SelectBlog_TagByID(int t_blog_tag_id)
        {
            Blog_TagEntity t_Blog_Tag= new Blog_TagEntity();
            OleDbDataReader sdr=null;
            using(sdr=OLEDBHelp.GetReader("select * from Blog_Tags where blog_tag_id="+t_blog_tag_id))
            {
                if(sdr.Read())
                {
                    t_Blog_Tag.Blog_tag_id=(int)sdr.GetValue(0);
                    t_Blog_Tag.Tag_id=(int)sdr.GetValue(1);
                    t_Blog_Tag.Blog_id=(int)sdr.GetValue(2);
                }
            }
            sdr.Close(); 
            return t_Blog_Tag;
        }
        public Blog_TagEntity SelectBlog_TagByBlogID(int t_blog_id)
        {
            Blog_TagEntity t_Blog_Tag = new Blog_TagEntity();
            OleDbDataReader sdr = null;
            using (sdr = OLEDBHelp.GetReader("select * from Blog_Tags where blog_id=" + t_blog_id))
            {
                if (sdr.Read())
                {
                    t_Blog_Tag.Blog_tag_id = (int)sdr.GetValue(0);
                    t_Blog_Tag.Tag_id = (int)sdr.GetValue(1);
                    t_Blog_Tag.Blog_id = (int)sdr.GetValue(2);
                }
            }
            sdr.Close();
            return t_Blog_Tag;
        }
        
        //根据主键查询整个表
        public IList<Blog_TagEntity> GetAllBlog_Tag()
        {
            IList<Blog_TagEntity> t_Blog_Tags = new List<Blog_TagEntity>();
            OleDbDataReader sdr = null;
            using(sdr=OLEDBHelp.GetReader("select * from Blog_Tags"))
            {
                while(sdr.Read())
                {
                    Blog_TagEntity t_Blog_Tag= new Blog_TagEntity();
                    t_Blog_Tag.Blog_tag_id=(int)sdr.GetValue(0);                  
                    t_Blog_Tag.Tag_id=(int)sdr.GetValue(1);                  
                    t_Blog_Tag.Blog_id=(int)sdr.GetValue(2);                  
                    t_Blog_Tags.Add(t_Blog_Tag);
                }
                sdr.Close();
            }
            return t_Blog_Tags;
        }
        
        
        //根据外键进行查询
        public IList<Blog_TagEntity> GetAllBlog_TagBytag_id(int t_tag_id)
        {
           IList<Blog_TagEntity> t_Blog_Tags = new List<Blog_TagEntity>();
           OleDbDataReader sdr = null;
           using(sdr=OLEDBHelp.GetReader("select * from Blog_Tags where tag_id="+t_tag_id))
           {
              while(sdr.Read())
                {
                    Blog_TagEntity t_Blog_Tag= new Blog_TagEntity();
                    t_Blog_Tag.Blog_tag_id=(int)sdr.GetValue(0);                    
                    t_Blog_Tag.Tag_id=(int)sdr.GetValue(1);                    
                    t_Blog_Tag.Blog_id=(int)sdr.GetValue(2);                    
                    t_Blog_Tags.Add(t_Blog_Tag);
                }
                sdr.Close();
            }
            return t_Blog_Tags;
        }
        

        
        //插入操作
        public int InsertBlog_Tag(Blog_TagEntity t_Blog_Tag)
        {
          //定义插入数据的参数数组
              OleDbParameter[] p=new OleDbParameter[]{
              new OleDbParameter("@Blog_tag_id",t_Blog_Tag.Blog_tag_id),
              new OleDbParameter("@Tag_id",t_Blog_Tag.Tag_id),
              new OleDbParameter("@Blog_id",t_Blog_Tag.Blog_id)
           };
           int i=OLEDBHelp.GetExecute("insert into Blog_Tags values (@Blog_tag_id,@Tag_id,@Blog_id)", p) ;
           return i;
        }
        
        public int UpdateBlog_Tag(Blog_TagEntity t_Blog_Tag)
        {
            OleDbParameter[] p=new OleDbParameter[]{
            new OleDbParameter("@Blog_tag_id",t_Blog_Tag.Blog_tag_id),
            new OleDbParameter("@Tag_id",t_Blog_Tag.Tag_id),
            new OleDbParameter("@Blog_id",t_Blog_Tag.Blog_id)
            };
            int i=OLEDBHelp.GetExecute("update Blog_Tags set blog_tag_id=@Blog_tag_id,blog_id=@Blog_id where blog_tag_id=@Blog_tag_id", p) ;
            return i;
        }
        
        public int DeleteBlog_Tag(int t_blog_tag_id)
        {
            int i=OLEDBHelp.GetExecute("delete from Blog_Tags where blog_tag_id="+t_blog_tag_id);
			return i;
        }


        IList<Blog_TagEntity> IBlog_Tag.SelectBlog_TagByBlogID(int t_blog_id)
        {
            throw new NotImplementedException();
        }
    }
}