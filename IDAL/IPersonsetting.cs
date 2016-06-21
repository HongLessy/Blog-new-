
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
    //Personsetting的描述
    ///
    public interface IPersonsetting
    {
          PersonsettingEntity SelectPersonsettingByID(int t_id);       
        //根据主键查询整个表
          IList<PersonsettingEntity> GetAllPersonsetting();      
        //根据外键进行查询
          IList<PersonsettingEntity> GetAllPersonsettingByauthor_id(int t_author_id);
          IList<PersonsettingEntity> GetAllPersonsettingBymodel_id(int t_model_id);
        //插入操作
          int InsertPersonsetting(PersonsettingEntity t_Personsetting);       
        //修改操作
          int UpdatePersonsetting(PersonsettingEntity t_Personsetting);
        //删除操作
          int DeletePersonsetting(int t_id);
       
    }
}