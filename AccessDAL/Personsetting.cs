
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
    //Personsetting的描述
    ///
    public class Personsetting:IPersonsetting
    {
    
        public PersonsettingEntity SelectPersonsettingByID(int t_id)
        {
            PersonsettingEntity t_Personsetting= new PersonsettingEntity();
            OleDbDataReader sdr=null;
            using(sdr=OLEDBHelp.GetReader("select * from Personsettings where id="+t_id))
            {
                if(sdr.Read())
                {
                    t_Personsetting.Id=(int)sdr.GetValue(0);
                    t_Personsetting.Author_id=(int)sdr.GetValue(1);
                    t_Personsetting.Blog_title=(string)sdr.GetValue(2);
                    t_Personsetting.Model_id=(int)sdr.GetValue(3);
                    t_Personsetting.Description=(string)sdr.GetValue(4);
                    t_Personsetting.Blog_path=(string)sdr.GetValue(5);
                    t_Personsetting.Rss_size=(int)sdr.GetValue(6);
                    t_Personsetting.Max_uploadfile=(int)sdr.GetValue(7);
                }
            }
            sdr.Close(); 
            return t_Personsetting;
        }
        
        //根据主键查询整个表
        public IList<PersonsettingEntity> GetAllPersonsetting()
        {
            IList<PersonsettingEntity> t_Personsettings = new List<PersonsettingEntity>();
            OleDbDataReader sdr = null;
            using(sdr=OLEDBHelp.GetReader("select * from Personsettings"))
            {
                while(sdr.Read())
                {
                    PersonsettingEntity t_Personsetting= new PersonsettingEntity();
                    t_Personsetting.Id=(int)sdr.GetValue(0);                  
                    t_Personsetting.Author_id=(int)sdr.GetValue(1);                  
                    t_Personsetting.Blog_title=(string)sdr.GetValue(2);                  
                    t_Personsetting.Model_id=(int)sdr.GetValue(3);                  
                    t_Personsetting.Description=(string)sdr.GetValue(4);                  
                    t_Personsetting.Blog_path=(string)sdr.GetValue(5);                  
                    t_Personsetting.Rss_size=(int)sdr.GetValue(6);                  
                    t_Personsetting.Max_uploadfile=(int)sdr.GetValue(7);                  
                    t_Personsettings.Add(t_Personsetting);
                }
                sdr.Close();
            }
            return t_Personsettings;
        }
        
        
        //根据外键进行查询
        public IList<PersonsettingEntity> GetAllPersonsettingByauthor_id(int t_author_id)
        {
           IList<PersonsettingEntity> t_Personsettings = new List<PersonsettingEntity>();
           OleDbDataReader sdr = null;
           using(sdr=OLEDBHelp.GetReader("select * from Personsettings where author_id="+t_author_id))
           {
              while(sdr.Read())
                {
                    PersonsettingEntity t_Personsetting= new PersonsettingEntity();
                    t_Personsetting.Id=(int)sdr.GetValue(0);                    
                    t_Personsetting.Author_id=(int)sdr.GetValue(1);                    
                    t_Personsetting.Blog_title=(string)sdr.GetValue(2);                    
                    t_Personsetting.Model_id=(int)sdr.GetValue(3);                    
                    t_Personsetting.Description=(string)sdr.GetValue(4);                    
                    t_Personsetting.Blog_path=(string)sdr.GetValue(5);                    
                    t_Personsetting.Rss_size=(int)sdr.GetValue(6);                    
                    t_Personsetting.Max_uploadfile=(int)sdr.GetValue(7);                    
                    t_Personsettings.Add(t_Personsetting);
                }
                sdr.Close();
            }
            return t_Personsettings;
        }
        public IList<PersonsettingEntity> GetAllPersonsettingBymodel_id(int t_model_id)
        {
           IList<PersonsettingEntity> t_Personsettings = new List<PersonsettingEntity>();
           OleDbDataReader sdr = null;
           using(sdr=OLEDBHelp.GetReader("select * from Personsettings where model_id="+t_model_id))
           {
              while(sdr.Read())
                {
                    PersonsettingEntity t_Personsetting= new PersonsettingEntity();
                    t_Personsetting.Id=(int)sdr.GetValue(0);                    
                    t_Personsetting.Author_id=(int)sdr.GetValue(1);                    
                    t_Personsetting.Blog_title=(string)sdr.GetValue(2);                    
                    t_Personsetting.Model_id=(int)sdr.GetValue(3);                    
                    t_Personsetting.Description=(string)sdr.GetValue(4);                    
                    t_Personsetting.Blog_path=(string)sdr.GetValue(5);                    
                    t_Personsetting.Rss_size=(int)sdr.GetValue(6);                    
                    t_Personsetting.Max_uploadfile=(int)sdr.GetValue(7);                    
                    t_Personsettings.Add(t_Personsetting);
                }
                sdr.Close();
            }
            return t_Personsettings;
        }
        

        
        //插入操作
        public int InsertPersonsetting(PersonsettingEntity t_Personsetting)
        {
          //定义插入数据的参数数组
              OleDbParameter[] p=new OleDbParameter[]{
              new OleDbParameter("@Id",t_Personsetting.Id),
              new OleDbParameter("@Author_id",t_Personsetting.Author_id),
              new OleDbParameter("@Blog_title",t_Personsetting.Blog_title),
              new OleDbParameter("@Model_id",t_Personsetting.Model_id),
              new OleDbParameter("@Description",t_Personsetting.Description),
              new OleDbParameter("@Blog_path",t_Personsetting.Blog_path),
              new OleDbParameter("@Rss_size",t_Personsetting.Rss_size),
              new OleDbParameter("@Max_uploadfile",t_Personsetting.Max_uploadfile)
           };
           int i=OLEDBHelp.GetExecute("insert into Personsettings values (@Id,@Author_id,@Blog_title,@Model_id,@Description,@Blog_path,@Rss_size,@Max_uploadfile)", p) ;
           return i;
        }
        
        public int UpdatePersonsetting(PersonsettingEntity t_Personsetting)
        {
            OleDbParameter[] p=new OleDbParameter[]{
            new OleDbParameter("@Id",t_Personsetting.Id),
            new OleDbParameter("@Author_id",t_Personsetting.Author_id),
            new OleDbParameter("@Blog_title",t_Personsetting.Blog_title),
            new OleDbParameter("@Model_id",t_Personsetting.Model_id),
            new OleDbParameter("@Description",t_Personsetting.Description),
            new OleDbParameter("@Blog_path",t_Personsetting.Blog_path),
            new OleDbParameter("@Rss_size",t_Personsetting.Rss_size),
            new OleDbParameter("@Max_uploadfile",t_Personsetting.Max_uploadfile)
            };
            int i=OLEDBHelp.GetExecute("update Personsettings set id=@Id,blog_title=@Blog_title,description=@Description,blog_path=@Blog_path,rss_size=@Rss_size,max_uploadfile=@Max_uploadfile where id=@Id", p) ;
            return i;
        }
        
        public int DeletePersonsetting(int t_id)
        {
            int i=OLEDBHelp.GetExecute("delete from Personsettings where id="+t_id);
			return i;
        }
    }
}