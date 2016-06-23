
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
    //Role的描述
    ///
    public static class RoleManager
    {
        private static Blog.IDAL.IRole dal=Blog.DALFactory.DataAccess.CreateRole();
        
        public static RoleEntity SelectRoleByID(int t_role_id)
        {
            RoleEntity temp=null;
            try
            {
                temp=dal.SelectRoleByID(t_role_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        //根据主键查询整个表
        public static IList<RoleEntity> GetAllRole()
        {
            IList<RoleEntity> temp=null;
            try
            {
                temp = dal.GetAllRole();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        
        //根据外键进行查询
        

        
        //插入操作
        public static int InsertRole(RoleEntity t_Role)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.InsertRole(t_Role);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return i;
        }
        
        public static int UpdateRole(RoleEntity t_Role)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.UpdateRole(t_Role);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
        
        public static int DeleteRole(int t_role_id)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i = dal.DeleteRole(t_role_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
    }
}