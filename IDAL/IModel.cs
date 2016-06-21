
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
    //Model的描述
    ///
    public interface IModel
    {
          ModelEntity SelectModelByID(int t_model_id);       
        //根据主键查询整个表
          IList<ModelEntity> GetAllModel();      
        //根据外键进行查询
        //插入操作
          int InsertModel(ModelEntity t_Model);       
        //修改操作
          int UpdateModel(ModelEntity t_Model);
        //删除操作
          int DeleteModel(int t_model_id);
       
    }
}