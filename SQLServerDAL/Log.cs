
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
    //Log的描述
    ///
    public class Log:ILog
    {
    
        public  LogEntity SelectLogByID(int t_id)
        {
            LogEntity t_Log= new LogEntity();
            SqlDataReader sdr=null;
            using(sdr=SqlDBHelp.GetReader("select * from Logs where id="+t_id))
            {
                if(sdr.Read())
                {
                    t_Log.Id=(int)sdr.GetValue(0);
                    t_Log.Author_id=(int)sdr.GetValue(1);
                    t_Log.Date=(DateTime)sdr.GetValue(2);
                    t_Log.Opevent=(string)sdr.GetValue(3);
                }
            }
            sdr.Close(); 
            return t_Log;
        }
        
        //根据主键查询整个表
        public IList<LogEntity> GetAllLog()
        {
            IList<LogEntity> t_Logs = new List<LogEntity>();
            SqlDataReader sdr = null;
            using(sdr=SqlDBHelp.GetReader("select * from Logs"))
            {
                while(sdr.Read())
                {
                    LogEntity t_Log= new LogEntity();
                    t_Log.Id=(int)sdr.GetValue(0);                  
                    t_Log.Author_id=(int)sdr.GetValue(1);                  
                    t_Log.Date=(DateTime)sdr.GetValue(2);                  
                    t_Log.Opevent=(string)sdr.GetValue(3);                  
                    t_Logs.Add(t_Log);
                }
                sdr.Close();
            }
            return t_Logs;
        }
        
        
        //根据外键进行查询
        public IList<LogEntity> GetAllLogByauthor_id(int t_author_id)
        {
           IList<LogEntity> t_Logs = new List<LogEntity>();
           SqlDataReader sdr = null;
           using(sdr=SqlDBHelp.GetReader("select * from Logs where author_id="+t_author_id))
           {
              while(sdr.Read())
                {
                    LogEntity t_Log= new LogEntity();
                    t_Log.Id=(int)sdr.GetValue(0);                    
                    t_Log.Author_id=(int)sdr.GetValue(1);                    
                    t_Log.Date=(DateTime)sdr.GetValue(2);                    
                    t_Log.Opevent=(string)sdr.GetValue(3);                    
                    t_Logs.Add(t_Log);
                }
                sdr.Close();
            }
            return t_Logs;
        }
        

        
        //插入操作
        public  int InsertLog(LogEntity t_Log)
        {
          //定义插入数据的参数数组
              SqlParameter[] p=new SqlParameter[]{
              new SqlParameter("@Id",t_Log.Id),
              new SqlParameter("@Author_id",t_Log.Author_id),
              new SqlParameter("@Date",t_Log.Date),
              new SqlParameter("@Opevent",t_Log.Opevent)
           };
           int i=SqlDBHelp.GetExecute("insert into Logs values (@Id,@Author_id,@Date,@Opevent)", p) ;
           return i;
        }
        
        public  int UpdateLog(LogEntity t_Log)
        {
            SqlParameter[] p=new SqlParameter[]{
            new SqlParameter("@Id",t_Log.Id),
            new SqlParameter("@Author_id",t_Log.Author_id),
            new SqlParameter("@Date",t_Log.Date),
            new SqlParameter("@Opevent",t_Log.Opevent)
            };
            int i=SqlDBHelp.GetExecute("update Logs set id=@Id,date=@Date,opevent=@Opevent where id=@Id", p) ;
            return i;
        }
        
        public int DeleteLog(int t_id)
        {
            int i=SqlDBHelp.GetExecute("delete from Logs where id="+t_id);
			return i;
        }
    }
}