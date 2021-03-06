﻿
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
    //Blogtype的描述
    ///
    public class Blogtype:IBlogtype
    {
    
        public  BlogtypeEntity SelectBlogtypeByID(int t_blogtype_id)
        {
            BlogtypeEntity t_Blogtype= new BlogtypeEntity();
            SqlDataReader sdr=null;
            using(sdr=SqlDBHelp.GetReader("select * from Blogtypes where blogtype_id="+t_blogtype_id))
            {
                if(sdr.Read())
                {
                    t_Blogtype.Blogtype_id=(int)sdr.GetValue(0);
                    t_Blogtype.Name=(string)sdr.GetValue(1);
                    t_Blogtype.Author_id=(int)sdr.GetValue(2);
                }
            }
            sdr.Close(); 
            return t_Blogtype;
        }
        
        //根据主键查询整个表
        public IList<BlogtypeEntity> GetAllBlogtype()
        {
            IList<BlogtypeEntity> t_Blogtypes = new List<BlogtypeEntity>();
            SqlDataReader sdr = null;
            using(sdr=SqlDBHelp.GetReader("select * from Blogtypes"))
            {
                while(sdr.Read())
                {
                    BlogtypeEntity t_Blogtype= new BlogtypeEntity();
                    t_Blogtype.Blogtype_id=(int)sdr.GetValue(0);                  
                    t_Blogtype.Name=(string)sdr.GetValue(1);                  
                    t_Blogtype.Author_id=(int)sdr.GetValue(2);                  
                    t_Blogtypes.Add(t_Blogtype);
                }
                sdr.Close();
            }
            return t_Blogtypes;
        }
        
        
        //根据外键进行查询
        public IList<BlogtypeEntity> GetAllBlogtypeByauthor_id(int t_author_id)
        {
           IList<BlogtypeEntity> t_Blogtypes = new List<BlogtypeEntity>();
           SqlDataReader sdr = null;
           using(sdr=SqlDBHelp.GetReader("select * from Blogtypes where author_id="+t_author_id))
           {
              while(sdr.Read())
                {
                    BlogtypeEntity t_Blogtype= new BlogtypeEntity();
                    t_Blogtype.Blogtype_id=(int)sdr.GetValue(0);                    
                    t_Blogtype.Name=(string)sdr.GetValue(1);                    
                    t_Blogtype.Author_id=(int)sdr.GetValue(2);                    
                    t_Blogtypes.Add(t_Blogtype);
                }
                sdr.Close();
            }
            return t_Blogtypes;
        }
        

        
        //插入操作
        public  int InsertBlogtype(BlogtypeEntity t_Blogtype)
        {
          //定义插入数据的参数数组
              SqlParameter[] p=new SqlParameter[]{
              new SqlParameter("@Blogtype_id",t_Blogtype.Blogtype_id),
              new SqlParameter("@Name",t_Blogtype.Name),
              new SqlParameter("@Author_id",t_Blogtype.Author_id)
           };
           int i=SqlDBHelp.GetExecute("insert into Blogtypes values (@Blogtype_id,@Name,@Author_id)", p) ;
           return i;
        }
        
        public  int UpdateBlogtype(BlogtypeEntity t_Blogtype)
        {
            SqlParameter[] p=new SqlParameter[]{
            new SqlParameter("@Blogtype_id",t_Blogtype.Blogtype_id),
            new SqlParameter("@Name",t_Blogtype.Name),
            new SqlParameter("@Author_id",t_Blogtype.Author_id)
            };
            int i=SqlDBHelp.GetExecute("update Blogtypes set blogtype_id=@Blogtype_id,name=@Name where blogtype_id=@Blogtype_id", p) ;
            return i;
        }
        
        public int DeleteBlogtype(int t_blogtype_id)
        {
            int i=SqlDBHelp.GetExecute("delete from Blogtypes where blogtype_id="+t_blogtype_id);
			return i;
        }
    }
}