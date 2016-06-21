
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

namespace Blog.IDAL
{
    
    ///
    //Log的描述
    ///
    public interface ILog
    {
          LogEntity SelectLogByID(int t_id);       
        //根据主键查询整个表
          IList<LogEntity> GetAllLog();      
        //根据外键进行查询
          IList<LogEntity> GetAllLogByauthor_id(int t_author_id);
        //插入操作
          int InsertLog(LogEntity t_Log);       
        //修改操作
          int UpdateLog(LogEntity t_Log);
        //删除操作
          int DeleteLog(int t_id);
       
    }
}