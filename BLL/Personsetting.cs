
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
    //Personsetting的描述
    ///
    public static class PersonsettingManager
    {
        private static Blog.IDAL.IPersonsetting dal=Blog.DALFactory.DataAccess.CreatePersonsetting();
        
        public static PersonsettingEntity SelectPersonsettingByID(int t_id)
        {
            PersonsettingEntity temp=null;
            try
            {
                temp=dal.SelectPersonsettingByID(t_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        //根据主键查询整个表
        public static IList<PersonsettingEntity> GetAllPersonsetting()
        {
            IList<PersonsettingEntity> temp=null;
            try
            {
                temp=GetAllPersonsetting();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        
        //根据外键进行查询
        public static IList<PersonsettingEntity> GetAllPersonsettingByauthor_id(int t_author_id)
        {
           IList<PersonsettingEntity> temp=null;
           try
            {
                temp=GetAllPersonsettingByauthor_id(t_author_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        public static IList<PersonsettingEntity> GetAllPersonsettingBymodel_id(int t_model_id)
        {
           IList<PersonsettingEntity> temp=null;
           try
            {
                temp=GetAllPersonsettingBymodel_id(t_model_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        

        
        //插入操作
        public static int InsertPersonsetting(PersonsettingEntity t_Personsetting)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=InsertPersonsetting(t_Personsetting);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return i;
        }
        
        public static int UpdatePersonsetting(PersonsettingEntity t_Personsetting)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=UpdatePersonsetting(t_Personsetting);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
        
        public static int DeletePersonsetting(int t_id)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=DeletePersonsetting(t_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
    }
}