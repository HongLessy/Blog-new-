
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
    //Tag的描述
    ///
    public class Tag:ITag
    {
    
        public  TagEntity SelectTagByID(int t_tag_id)
        {
            TagEntity t_Tag= new TagEntity();
            SqlDataReader sdr=null;
            using(sdr=SqlDBHelp.GetReader("select * from Tags where tag_id="+t_tag_id))
            {
                if(sdr.Read())
                {
                    t_Tag.Tag_id=(int)sdr.GetValue(0);
                    t_Tag.TagName=(string)sdr.GetValue(1);
                    t_Tag.Author_id = (int)sdr.GetValue(2);
                }
            }
            sdr.Close(); 
            return t_Tag;
        }
        
        //根据主键查询整个表
        public IList<TagEntity> GetAllTag()
        {
            IList<TagEntity> t_Tags = new List<TagEntity>();
            SqlDataReader sdr = null;
            using(sdr=SqlDBHelp.GetReader("select * from Tags"))
            {
                while(sdr.Read())
                {
                    TagEntity t_Tag= new TagEntity();
                    t_Tag.Tag_id=(int)sdr.GetValue(0);                  
                    t_Tag.TagName=(string)sdr.GetValue(1);
                    t_Tag.Author_id = (int)sdr.GetValue(2); 
                    t_Tags.Add(t_Tag);
                }
                sdr.Close();
            }
            return t_Tags;
        }
        
        
        //根据外键进行查询
        

        
        //插入操作
        public  int InsertTag(TagEntity t_Tag)
        {
          //定义插入数据的参数数组
              SqlParameter[] p=new SqlParameter[]{
              new SqlParameter("@Tag_id",t_Tag.Tag_id),
              new SqlParameter("@TagName",t_Tag.TagName),
              new SqlParameter("@Author_id",t_Tag.Author_id)
           };
           int i=SqlDBHelp.GetExecute("insert into Tags values (@Tag_id,@TagName,@Author_id)", p) ;
           return i;
        }
        
        public  int UpdateTag(TagEntity t_Tag)
        {
            SqlParameter[] p=new SqlParameter[]{
            new SqlParameter("@Tag_id",t_Tag.Tag_id),
            new SqlParameter("@TagName",t_Tag.TagName),
            new SqlParameter("@Author_id",t_Tag.Author_id)
            };
            int i=SqlDBHelp.GetExecute("update Tags set tag_id=@Tag_id,tagName=@TagName,anthor_id=@Author_id where tag_id=@Tag_id", p) ;
            return i;
        }
        
        public int DeleteTag(int t_tag_id)
        {
            int i=SqlDBHelp.GetExecute("delete from Tags where tag_id="+t_tag_id);
			return i;
        }
    }
}