
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
    //File的描述
    ///
    public class File:IFile
    {
    
        public  FileEntity SelectFileByID(int t_id)
        {
            FileEntity t_File= new FileEntity();
            SqlDataReader sdr=null;
            using(sdr=SqlDBHelp.GetReader("select * from Files where id="+t_id))
            {
                if(sdr.Read())
                {
                    t_File.Id=(int)sdr.GetValue(0);
                    t_File.Filename=(string)sdr.GetValue(1);
                    t_File.Mime=(string)sdr.GetValue(2);
                    t_File.Filecontent=(byte[])sdr.GetValue(3);
                    t_File.Author_id=(int)sdr.GetValue(4);
                }
            }
            sdr.Close(); 
            return t_File;
        }
        
        //根据主键查询整个表
        public IList<FileEntity> GetAllFile()
        {
            IList<FileEntity> t_Files = new List<FileEntity>();
            SqlDataReader sdr = null;
            using(sdr=SqlDBHelp.GetReader("select * from Files"))
            {
                while(sdr.Read())
                {
                    FileEntity t_File= new FileEntity();
                    t_File.Id=(int)sdr.GetValue(0);                  
                    t_File.Filename=(string)sdr.GetValue(1);                  
                    t_File.Mime=(string)sdr.GetValue(2);                  
                    t_File.Filecontent=(byte[])sdr.GetValue(3);                  
                    t_File.Author_id=(int)sdr.GetValue(4);                  
                    t_Files.Add(t_File);
                }
                sdr.Close();
            }
            return t_Files;
        }
        
        
        //根据外键进行查询
        public IList<FileEntity> GetAllFileByauthor_id(int t_author_id)
        {
           IList<FileEntity> t_Files = new List<FileEntity>();
           SqlDataReader sdr = null;
           using(sdr=SqlDBHelp.GetReader("select * from Files where author_id="+t_author_id))
           {
              while(sdr.Read())
                {
                    FileEntity t_File= new FileEntity();
                    t_File.Id=(int)sdr.GetValue(0);                    
                    t_File.Filename=(string)sdr.GetValue(1);                    
                    t_File.Mime=(string)sdr.GetValue(2);                    
                    t_File.Filecontent=(byte[])sdr.GetValue(3);                    
                    t_File.Author_id=(int)sdr.GetValue(4);                    
                    t_Files.Add(t_File);
                }
                sdr.Close();
            }
            return t_Files;
        }
        

        
        //插入操作
        public  int InsertFile(FileEntity t_File)
        {
          //定义插入数据的参数数组
              SqlParameter[] p=new SqlParameter[]{
              new SqlParameter("@Id",t_File.Id),
              new SqlParameter("@Filename",t_File.Filename),
              new SqlParameter("@Mime",t_File.Mime),
              new SqlParameter("@Filecontent",t_File.Filecontent),
              new SqlParameter("@Author_id",t_File.Author_id)
           };
           int i=SqlDBHelp.GetExecute("insert into Files values (@Id,@Filename,@Mime,@Filecontent,@Author_id)", p) ;
           return i;
        }
        
        public  int UpdateFile(FileEntity t_File)
        {
            SqlParameter[] p=new SqlParameter[]{
            new SqlParameter("@Id",t_File.Id),
            new SqlParameter("@Filename",t_File.Filename),
            new SqlParameter("@Mime",t_File.Mime),
            new SqlParameter("@Filecontent",t_File.Filecontent),
            new SqlParameter("@Author_id",t_File.Author_id)
            };
            int i=SqlDBHelp.GetExecute("update Files set id=@Id,filename=@Filename,mime=@Mime,filecontent=@Filecontent where id=@Id", p) ;
            return i;
        }
        
        public int DeleteFile(int t_id)
        {
            int i=SqlDBHelp.GetExecute("delete from Files where id="+t_id);
			return i;
        }
    }
}