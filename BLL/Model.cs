
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
    //Model的描述
    ///
    public static class ModelManager
    {
        private static Blog.IDAL.IModel dal=Blog.DALFactory.DataAccess.CreateModel();
        
        public static ModelEntity SelectModelByID(int t_model_id)
        {
            ModelEntity temp=null;
            try
            {
                temp=dal.SelectModelByID(t_model_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        //根据主键查询整个表
        public static IList<ModelEntity> GetAllModel()
        {
            IList<ModelEntity> temp=null;
            try
            {
                temp = dal.GetAllModel();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        
        //根据外键进行查询
        

        
        //插入操作
        public static int InsertModel(ModelEntity t_Model)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.InsertModel(t_Model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return i;
        }
        
        public static int UpdateModel(ModelEntity t_Model)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.UpdateModel(t_Model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
        
        public static int DeleteModel(int t_model_id)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.DeleteModel(t_model_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
    }
}