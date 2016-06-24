
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
    //Blogentrie的描述
    ///
    public class Blogentrie:IBlogentrie
    {
    
        public BlogentrieEntity SelectBlogentrieByID(int t_blog_id)
        {
            BlogentrieEntity t_Blogentrie= new BlogentrieEntity();
            OleDbDataReader sdr=null;
            using(sdr=OLEDBHelp.GetReader("select * from Blogentries where blog_id="+t_blog_id))
            {
                if(sdr.Read())
                {
                    t_Blogentrie.Blog_id=(int)sdr.GetValue(0);
                    t_Blogentrie.Author_id=(int)sdr.GetValue(1);
                    t_Blogentrie.Title=(string)sdr.GetValue(2);
                    t_Blogentrie.Description=(string)sdr.GetValue(3);
                    t_Blogentrie.Type=(string)sdr.GetValue(4);
                    t_Blogentrie.Allowcomment=(string)sdr.GetValue(5);
                    t_Blogentrie.Markprivate=(string)sdr.GetValue(6);
                    t_Blogentrie.Body=(string)sdr.GetValue(7);
                    t_Blogentrie.Datecreated=(DateTime)sdr.GetValue(8);
                    t_Blogentrie.Datepublished=(DateTime)sdr.GetValue(9);
                    t_Blogentrie.Datemodified=(DateTime)sdr.GetValue(10);
                    t_Blogentrie.Islock=(string)sdr.GetValue(11);
                    t_Blogentrie.Blogtype_id=(int)sdr.GetValue(12);
                }
            }
            sdr.Close(); 
            return t_Blogentrie;
        }
        
        //根据主键查询整个表
        public IList<BlogentrieEntity> GetAllBlogentrie()
        {
            IList<BlogentrieEntity> t_Blogentries = new List<BlogentrieEntity>();
            OleDbDataReader sdr = null;
            using(sdr=OLEDBHelp.GetReader("select * from Blogentries"))
            {
                while(sdr.Read())
                {
                    BlogentrieEntity t_Blogentrie= new BlogentrieEntity();
                    t_Blogentrie.Blog_id=(int)sdr.GetValue(0);                  
                    t_Blogentrie.Author_id=(int)sdr.GetValue(1);                  
                    t_Blogentrie.Title=(string)sdr.GetValue(2);                  
                    t_Blogentrie.Description=(string)sdr.GetValue(3);                  
                    t_Blogentrie.Type=(string)sdr.GetValue(4);                  
                    t_Blogentrie.Allowcomment=(string)sdr.GetValue(5);                  
                    t_Blogentrie.Markprivate=(string)sdr.GetValue(6);                  
                    t_Blogentrie.Body=(string)sdr.GetValue(7);                  
                    t_Blogentrie.Datecreated=(DateTime)sdr.GetValue(8);                  
                    t_Blogentrie.Datepublished=(DateTime)sdr.GetValue(9);                  
                    t_Blogentrie.Datemodified=(DateTime)sdr.GetValue(10);                  
                    t_Blogentrie.Islock=(string)sdr.GetValue(11);                  
                    t_Blogentrie.Blogtype_id=(int)sdr.GetValue(12);                  
                    t_Blogentries.Add(t_Blogentrie);
                }
                sdr.Close();
            }
            return t_Blogentries;
        }
        
        
        //根据外键进行查询
        public IList<BlogentrieEntity> GetAllBlogentrieByauthor_id(int t_author_id)
        {
           IList<BlogentrieEntity> t_Blogentries = new List<BlogentrieEntity>();
           OleDbDataReader sdr = null;
           using(sdr=OLEDBHelp.GetReader("select * from Blogentries where author_id="+t_author_id))
           {
              while(sdr.Read())
                {
                    BlogentrieEntity t_Blogentrie= new BlogentrieEntity();
                    t_Blogentrie.Blog_id=(int)sdr.GetValue(0);                    
                    t_Blogentrie.Author_id=(int)sdr.GetValue(1);                    
                    t_Blogentrie.Title=(string)sdr.GetValue(2);                    
                    t_Blogentrie.Description=(string)sdr.GetValue(3);                    
                    t_Blogentrie.Type=(string)sdr.GetValue(4);                    
                    t_Blogentrie.Allowcomment=(string)sdr.GetValue(5);                    
                    t_Blogentrie.Markprivate=(string)sdr.GetValue(6);                    
                    t_Blogentrie.Body=(string)sdr.GetValue(7);                    
                    t_Blogentrie.Datecreated=(DateTime)sdr.GetValue(8);                    
                    t_Blogentrie.Datepublished=(DateTime)sdr.GetValue(9);                    
                    t_Blogentrie.Datemodified=(DateTime)sdr.GetValue(10);                    
                    t_Blogentrie.Islock=(string)sdr.GetValue(11);                    
                    t_Blogentrie.Blogtype_id=(int)sdr.GetValue(12);                    
                    t_Blogentries.Add(t_Blogentrie);
                }
                sdr.Close();
            }
            return t_Blogentries;
        }
        public IList<BlogentrieEntity> GetAllBlogentrieByblogtype_id(int t_blogtype_id)
        {
           IList<BlogentrieEntity> t_Blogentries = new List<BlogentrieEntity>();
           OleDbDataReader sdr = null;
           using(sdr=OLEDBHelp.GetReader("select * from Blogentries where blogtype_id="+t_blogtype_id))
           {
              while(sdr.Read())
                {
                    BlogentrieEntity t_Blogentrie= new BlogentrieEntity();
                    t_Blogentrie.Blog_id=(int)sdr.GetValue(0);                    
                    t_Blogentrie.Author_id=(int)sdr.GetValue(1);                    
                    t_Blogentrie.Title=(string)sdr.GetValue(2);                    
                    t_Blogentrie.Description=(string)sdr.GetValue(3);                    
                    t_Blogentrie.Type=(string)sdr.GetValue(4);                    
                    t_Blogentrie.Allowcomment=(string)sdr.GetValue(5);                    
                    t_Blogentrie.Markprivate=(string)sdr.GetValue(6);                    
                    t_Blogentrie.Body=(string)sdr.GetValue(7);                    
                    t_Blogentrie.Datecreated=(DateTime)sdr.GetValue(8);                    
                    t_Blogentrie.Datepublished=(DateTime)sdr.GetValue(9);                    
                    t_Blogentrie.Datemodified=(DateTime)sdr.GetValue(10);                    
                    t_Blogentrie.Islock=(string)sdr.GetValue(11);                    
                    t_Blogentrie.Blogtype_id=(int)sdr.GetValue(12);                    
                    t_Blogentries.Add(t_Blogentrie);
                }
                sdr.Close();
            }
            return t_Blogentries;
        }
        

        
        //插入操作
        public int InsertBlogentrie(BlogentrieEntity t_Blogentrie)
        {
          //定义插入数据的参数数组
              OleDbParameter[] p=new OleDbParameter[]{
              new OleDbParameter("@Blog_id",t_Blogentrie.Blog_id),
              new OleDbParameter("@Author_id",t_Blogentrie.Author_id),
              new OleDbParameter("@Title",t_Blogentrie.Title),
              new OleDbParameter("@Description",t_Blogentrie.Description),
              new OleDbParameter("@Type",t_Blogentrie.Type),
              new OleDbParameter("@Allowcomment",t_Blogentrie.Allowcomment),
              new OleDbParameter("@Markprivate",t_Blogentrie.Markprivate),
              new OleDbParameter("@Body",t_Blogentrie.Body),
              new OleDbParameter("@Datecreated",t_Blogentrie.Datecreated),
              new OleDbParameter("@Datepublished",t_Blogentrie.Datepublished),
              new OleDbParameter("@Datemodified",t_Blogentrie.Datemodified),
              new OleDbParameter("@Islock",t_Blogentrie.Islock),
              new OleDbParameter("@Blogtype_id",t_Blogentrie.Blogtype_id)
           };
           int i=OLEDBHelp.GetExecute("insert into Blogentries values (@Blog_id,@Author_id,@Title,@Description,@Type,@Allowcomment,@Markprivate,@Body,@Datecreated,@Datepublished,@Datemodified,@Islock,@Blogtype_id)", p) ;
           return i;
        }
        
        public int UpdateBlogentrie(BlogentrieEntity t_Blogentrie)
        {
            OleDbParameter[] p=new OleDbParameter[]{
            new OleDbParameter("@Blog_id",t_Blogentrie.Blog_id),
            new OleDbParameter("@Author_id",t_Blogentrie.Author_id),
            new OleDbParameter("@Title",t_Blogentrie.Title),
            new OleDbParameter("@Description",t_Blogentrie.Description),
            new OleDbParameter("@Type",t_Blogentrie.Type),
            new OleDbParameter("@Allowcomment",t_Blogentrie.Allowcomment),
            new OleDbParameter("@Markprivate",t_Blogentrie.Markprivate),
            new OleDbParameter("@Body",t_Blogentrie.Body),
            new OleDbParameter("@Datecreated",t_Blogentrie.Datecreated),
            new OleDbParameter("@Datepublished",t_Blogentrie.Datepublished),
            new OleDbParameter("@Datemodified",t_Blogentrie.Datemodified),
            new OleDbParameter("@Islock",t_Blogentrie.Islock),
            new OleDbParameter("@Blogtype_id",t_Blogentrie.Blogtype_id)
            };
            int i=OLEDBHelp.GetExecute("update Blogentries set blog_id=@Blog_id,title=@Title,description=@Description,type=@Type,allowcomment=@Allowcomment,markprivate=@Markprivate,body=@Body,datecreated=@Datecreated,datepublished=@Datepublished,datemodified=@Datemodified,islock=@Islock where blog_id=@Blog_id", p) ;
            return i;
        }
        
        public int DeleteBlogentrie(int t_blog_id)
        {
            int i=OLEDBHelp.GetExecute("delete from Blogentries where blog_id="+t_blog_id);
			return i;
        }

        public int GetMaxBlogID()
        {
            throw new NotImplementedException();
        }
    }
}