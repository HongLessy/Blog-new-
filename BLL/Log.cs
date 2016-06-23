
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
    //Log的描述
    ///
    public static class LogManager
    {
        private static Blog.IDAL.ILog dal=Blog.DALFactory.DataAccess.CreateLog();
        
        public static LogEntity SelectLogByID(int t_id)
        {
            LogEntity temp=null;
            try
            {
                temp=dal.SelectLogByID(t_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        //根据主键查询整个表
        public static IList<LogEntity> GetAllLog()
        {
            IList<LogEntity> temp=null;
            try
            {
                temp = dal.GetAllLog();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        
        //根据外键进行查询
        public static IList<LogEntity> GetAllLogByauthor_id(int t_author_id)
        {
           IList<LogEntity> temp=null;
           try
            {
                temp = dal.GetAllLogByauthor_id(t_author_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        

        
        //插入操作
        public static int InsertLog(LogEntity t_Log)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.InsertLog(t_Log);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return i;
        }
        
        public static int UpdateLog(LogEntity t_Log)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.UpdateLog(t_Log);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
        
        public static int DeleteLog(int t_id)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.DeleteLog(t_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
    }
}