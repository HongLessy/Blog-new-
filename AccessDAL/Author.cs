
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
    //author的描述
    ///
    public class author:IAuthor
    {

        public AuthorEntity SelectauthorByID(int t_author_id)
        {
            AuthorEntity t_author = new AuthorEntity();
            OleDbDataReader sdr=null;
            using(sdr=OLEDBHelp.GetReader("select * from author where author_id="+t_author_id))
            {
                if(sdr.Read())
                {
                    t_author.Author_id=(int)sdr.GetValue(0);
                    t_author.Username=(string)sdr.GetValue(1);
                    t_author.Password=(string)sdr.GetValue(2);
                    t_author.Role_id=(int)sdr.GetValue(3);
                    t_author.Islock=(string)sdr.GetValue(4);
                    t_author.Email=(string)sdr.GetValue(5);
                }
            }
            sdr.Close(); 
            return t_author;
        }
        
        //根据主键查询整个表
        public IList<AuthorEntity> GetAllauthor()
        {
            IList<AuthorEntity> t_authors = new List<AuthorEntity>();
            OleDbDataReader sdr = null;
            using(sdr=OLEDBHelp.GetReader("select * from author"))
            {
                while(sdr.Read())
                {
                    AuthorEntity t_author = new AuthorEntity();
                    t_author.Author_id=(int)sdr.GetValue(0);                  
                    t_author.Username=(string)sdr.GetValue(1);                  
                    t_author.Password=(string)sdr.GetValue(2);                  
                    t_author.Role_id=(int)sdr.GetValue(3);                  
                    t_author.Islock=(string)sdr.GetValue(4);                  
                    t_author.Email=(string)sdr.GetValue(5);                  
                    t_authors.Add(t_author);
                }
                sdr.Close();
            }
            return t_authors;
        }
        
        
        //根据外键进行查询
        public IList<AuthorEntity> GetAllauthorByrole_id(int t_role_id)
        {
            IList<AuthorEntity> t_authors = new List<AuthorEntity>();
           OleDbDataReader sdr = null;
           using(sdr=OLEDBHelp.GetReader("select * from author where role_id="+t_role_id))
           {
              while(sdr.Read())
                {
                    AuthorEntity t_author = new AuthorEntity();
                    t_author.Author_id=(int)sdr.GetValue(0);                    
                    t_author.Username=(string)sdr.GetValue(1);                    
                    t_author.Password=(string)sdr.GetValue(2);                    
                    t_author.Role_id=(int)sdr.GetValue(3);                    
                    t_author.Islock=(string)sdr.GetValue(4);                    
                    t_author.Email=(string)sdr.GetValue(5);                    
                    t_authors.Add(t_author);
                }
                sdr.Close();
            }
            return t_authors;
        }
        

        
        //插入操作
        public int Insertauthor(AuthorEntity t_author)
        {
          //定义插入数据的参数数组
              OleDbParameter[] p=new OleDbParameter[]{
              new OleDbParameter("@Author_id",t_author.Author_id),
              new OleDbParameter("@Username",t_author.Username),
              new OleDbParameter("@Password",t_author.Password),
              new OleDbParameter("@Role_id",t_author.Role_id),
              new OleDbParameter("@Islock",t_author.Islock),
              new OleDbParameter("@Email",t_author.Email)
           };
           int i=OLEDBHelp.GetExecute("insert into author values (@Author_id,@Username,@Password,@Role_id,@Islock,@Email)", p) ;
           return i;
        }

        public int Updateauthor(AuthorEntity t_author)
        {
            OleDbParameter[] p=new OleDbParameter[]{
            new OleDbParameter("@Author_id",t_author.Author_id),
            new OleDbParameter("@Username",t_author.Username),
            new OleDbParameter("@Password",t_author.Password),
            new OleDbParameter("@Role_id",t_author.Role_id),
            new OleDbParameter("@Islock",t_author.Islock),
            new OleDbParameter("@Email",t_author.Email)
            };
            int i=OLEDBHelp.GetExecute("update author set author_id=@Author_id,username=@Username,password=@Password,islock=@Islock,email=@Email where author_id=@Author_id", p) ;
            return i;
        }
        
        public int Deleteauthor(int t_author_id)
        {
            int i=OLEDBHelp.GetExecute("delete from author where author_id="+t_author_id);
			return i;
        }
    }
}