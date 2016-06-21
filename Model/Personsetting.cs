///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System;

namespace Blog.Model
{
	public class PersonsettingEntity
	{
		protected int _id;
		protected int _author_id;
		protected string _blog_title = String.Empty;
		protected int _model_id;
		protected string _description = String.Empty;
		protected string _blog_path = String.Empty;
		protected int _rss_size;
		protected int _max_uploadfile;
	
		public PersonsettingEntity()
		{
			
		}
		
		public PersonsettingEntity(int id,int author_id,string blog_title,int model_id,string description,string blog_path,int rss_size,int max_uploadfile)
		{
			_id = id ;	
			_author_id = author_id ;	
			_blog_title = blog_title ;	
			_model_id = model_id ;	
			_description = description ;	
			_blog_path = blog_path ;	
			_rss_size = rss_size ;	
			_max_uploadfile = max_uploadfile ;	
		}
		
		public int  Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id=value;
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
			
		public string  Blog_title
		{
			get
			{
				return _blog_title;
			}
			set
			{
				_blog_title=value;
			}				
		}
			
		public int  Model_id
		{
			get
			{
				return _model_id;
			}
			set
			{
				_model_id=value;
			}				
		}
			
		public string  Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description=value;
			}				
		}
			
		public string  Blog_path
		{
			get
			{
				return _blog_path;
			}
			set
			{
				_blog_path=value;
			}				
		}
			
		public int  Rss_size
		{
			get
			{
				return _rss_size;
			}
			set
			{
				_rss_size=value;
			}				
		}
			
		public int  Max_uploadfile
		{
			get
			{
				return _max_uploadfile;
			}
			set
			{
				_max_uploadfile=value;
			}				
		}
			
	}
}


