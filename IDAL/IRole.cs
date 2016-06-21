
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
    //Role的描述
    ///
    public interface IRole
    {
          RoleEntity SelectRoleByID(int t_role_id);       
        //根据主键查询整个表
          IList<RoleEntity> GetAllRole();      
        //根据外键进行查询
        //插入操作
          int InsertRole(RoleEntity t_Role);       
        //修改操作
          int UpdateRole(RoleEntity t_Role);
        //删除操作
          int DeleteRole(int t_role_id);
       
    }
}