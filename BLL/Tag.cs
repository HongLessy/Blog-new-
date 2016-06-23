
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
    //Tag的描述
    ///
    public static class TagManager
    {
        private static Blog.IDAL.ITag dal=Blog.DALFactory.DataAccess.CreateTag();
        
        public static TagEntity SelectTagByID(int t_tag_id)
        {
            TagEntity temp=null;
            try
            {
                temp=dal.SelectTagByID(t_tag_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        //根据主键查询整个表
        public static IList<TagEntity> GetAllTag()
        {
            IList<TagEntity> temp=null;
            try
            {
                temp=dal.GetAllTag();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }
        
        
        //根据外键进行查询
        

        
        //插入操作
        public static int InsertTag(TagEntity t_Tag)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=dal.InsertTag(t_Tag);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return i;
        }
        
        public static int UpdateTag(TagEntity t_Tag)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=dal.UpdateTag(t_Tag);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
        
        public static int DeleteTag(int t_tag_id)
        {
            int i=-1;
            //定义插入数据的参数数组
            try
            {
                i=dal.DeleteTag(t_tag_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
    }
}