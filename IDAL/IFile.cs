
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
    //File的描述
    ///
    public interface IFile
    {
          FileEntity SelectFileByID(int t_id);       
        //根据主键查询整个表
          IList<FileEntity> GetAllFile();      
        //根据外键进行查询
          IList<FileEntity> GetAllFileByauthor_id(int t_author_id);
        //插入操作
          int InsertFile(FileEntity t_File);       
        //修改操作
          int UpdateFile(FileEntity t_File);
        //删除操作
          int DeleteFile(int t_id);
       
    }
}