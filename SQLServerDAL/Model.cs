
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
    //Model的描述
    ///
    public class Model:IModel
    {
    
        public  ModelEntity SelectModelByID(int t_model_id)
        {
            ModelEntity t_Model= new ModelEntity();
            SqlDataReader sdr=null;
            using(sdr=SqlDBHelp.GetReader("select * from Model where model_id="+t_model_id))
            {
                if(sdr.Read())
                {
                    t_Model.Model_id=(int)sdr.GetValue(0);
                    t_Model.Name=(string)sdr.GetValue(1);
                    t_Model.Path=(string)sdr.GetValue(2);
                }
            }
            sdr.Close(); 
            return t_Model;
        }
        
        //根据主键查询整个表
        public IList<ModelEntity> GetAllModel()
        {
            IList<ModelEntity> t_Models = new List<ModelEntity>();
            SqlDataReader sdr = null;
            using(sdr=SqlDBHelp.GetReader("select * from Model"))
            {
                while(sdr.Read())
                {
                    ModelEntity t_Model= new ModelEntity();
                    t_Model.Model_id=(int)sdr.GetValue(0);                  
                    t_Model.Name=(string)sdr.GetValue(1);                  
                    t_Model.Path=(string)sdr.GetValue(2);                  
                    t_Models.Add(t_Model);
                }
                sdr.Close();
            }
            return t_Models;
        }
        
        
        //根据外键进行查询
        

        
        //插入操作
        public  int InsertModel(ModelEntity t_Model)
        {
          //定义插入数据的参数数组
              SqlParameter[] p=new SqlParameter[]{
              new SqlParameter("@Model_id",t_Model.Model_id),
              new SqlParameter("@Name",t_Model.Name),
              new SqlParameter("@Path",t_Model.Path)
           };
           int i=SqlDBHelp.GetExecute("insert into Model values (@Model_id,@Name,@Path)", p) ;
           return i;
        }
        
        public  int UpdateModel(ModelEntity t_Model)
        {
            SqlParameter[] p=new SqlParameter[]{ 
            new SqlParameter("@Model_id",t_Model.Model_id),	
            new SqlParameter("@Name",t_Model.Name),
            new SqlParameter("@Path",t_Model.Path)
            };
            int i=SqlDBHelp.GetExecute("update Model set name=@Name,path=@Path where model_id=@Model_id", p) ;
            return i;
        }
        
        public int DeleteModel(int t_model_id)
        {
            int i=SqlDBHelp.GetExecute("delete from Model where model_id="+t_model_id);
			return i;
        }
    }
}