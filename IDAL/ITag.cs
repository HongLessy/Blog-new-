
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
    //Tag的描述
    ///
    public interface ITag
    {
          TagEntity SelectTagByID(int t_tag_id);       
        //根据主键查询整个表
          IList<TagEntity> GetAllTag();      
        //根据外键进行查询
        //插入操作
          int InsertTag(TagEntity t_Tag);       
        //修改操作
          int UpdateTag(TagEntity t_Tag);
        //删除操作
          int DeleteTag(int t_tag_id);
       
    }
}