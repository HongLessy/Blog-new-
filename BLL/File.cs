
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
    //File的描述
    ///
    public static class FileManager
    {
        private static Blog.IDAL.IFile dal=Blog.DALFactory.DataAccess.CreateFile();
        
        public static FileEntity SelectFileByID(int t_id)
        {
            FileEntity temp=null;
            try
            {
                temp=dal.SelectFileByID(t_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        //根据主键查询整个表
        public static IList<FileEntity> GetAllFile()
        {
            IList<FileEntity> temp=null;
            try
            {
                temp = dal.GetAllFile();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        
        //根据外键进行查询
        public static IList<FileEntity> GetAllFileByauthor_id(int t_author_id)
        {
           IList<FileEntity> temp=null;
           try
            {
                temp = dal.GetAllFileByauthor_id(t_author_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        

        
        //插入操作
        public static int InsertFile(FileEntity t_File)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.InsertFile(t_File);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return i;
        }
        
        public static int UpdateFile(FileEntity t_File)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.UpdateFile(t_File);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
        
        public static int DeleteFile(int t_id)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.DeleteFile(t_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
    }
}