
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
    //Role的描述
    ///
    public class Role:IRole
    {
    
        public  RoleEntity SelectRoleByID(int t_role_id)
        {
            RoleEntity t_Role= new RoleEntity();
            SqlDataReader sdr=null;
            using(sdr=SqlDBHelp.GetReader("select * from Role where role_id="+t_role_id))
            {
                if(sdr.Read())
                {
                    t_Role.Role_id=(int)sdr.GetValue(0);
                    t_Role.Name=(string)sdr.GetValue(1);
                }
            }
            sdr.Close(); 
            return t_Role;
        }
        
        //根据主键查询整个表
        public IList<RoleEntity> GetAllRole()
        {
            IList<RoleEntity> t_Roles = new List<RoleEntity>();
            SqlDataReader sdr = null;
            using(sdr=SqlDBHelp.GetReader("select * from Role"))
            {
                while(sdr.Read())
                {
                    RoleEntity t_Role= new RoleEntity();
                    t_Role.Role_id=(int)sdr.GetValue(0);                  
                    t_Role.Name=(string)sdr.GetValue(1);                  
                    t_Roles.Add(t_Role);
                }
                sdr.Close();
            }
            return t_Roles;
        }
        
        
        //根据外键进行查询
        

        
        //插入操作
        public  int InsertRole(RoleEntity t_Role)
        {
          //定义插入数据的参数数组
              SqlParameter[] p=new SqlParameter[]{
              new SqlParameter("@Role_id",t_Role.Role_id),
              new SqlParameter("@Name",t_Role.Name)
           };
           int i=SqlDBHelp.GetExecute("insert into Role values (@Role_id,@Name)", p) ;
           return i;
        }
        
        public  int UpdateRole(RoleEntity t_Role)
        {
            SqlParameter[] p=new SqlParameter[]{
            new SqlParameter("@Role_id",t_Role.Role_id),
            new SqlParameter("@Name",t_Role.Name)
            };
            int i=SqlDBHelp.GetExecute("update Role set role_id=@Role_id,name=@Name where role_id=@Role_id", p) ;
            return i;
        }
        
        public int DeleteRole(int t_role_id)
        {
            int i=SqlDBHelp.GetExecute("delete from Role where role_id="+t_role_id);
			return i;
        }
    }
}