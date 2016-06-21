///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System;

namespace Blog.Model
{
	public class BlogtypeEntity
	{
		protected int _blogtype_id;
		protected string _name = String.Empty;
		protected int _author_id;
	
		public BlogtypeEntity()
		{
			
		}
		
		public BlogtypeEntity(int blogtype_id,string name,int author_id)
		{
			_blogtype_id = blogtype_id ;	
			_name = name ;	
			_author_id = author_id ;	
		}
		
		public int  Blogtype_id
		{
			get
			{
				return _blogtype_id;
			}
			set
			{
				_blogtype_id=value;
			}				
		}
			
		public string  Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}				
		}
			
		public int  Author_id
		{
			get
			{
				return _author_id;
			}
			set
			{
				_author_id=value;
			}				
		}
			
	}
}


