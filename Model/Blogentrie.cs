///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System;

namespace Blog.Model
{
	public class BlogentrieEntity
	{
		protected int _blog_id;
		protected int _author_id;
		protected string _title = String.Empty;
		protected string _description = String.Empty;
		protected string _type = String.Empty;
		protected string _allowcomment = String.Empty;
		protected string _markprivate = String.Empty;
		protected string _body = String.Empty;
		protected DateTime _datecreated;
		protected DateTime _datepublished;
		protected DateTime _datemodified;
		protected string _islock = String.Empty;
		protected int _blogtype_id;
	
		public BlogentrieEntity()
		{
			
		}
		
		public BlogentrieEntity(int blog_id,int author_id,string title,string description,string type,string allowcomment,string markprivate,string body,DateTime datecreated,DateTime datepublished,DateTime datemodified,string islock,int blogtype_id)
		{
			_blog_id = blog_id ;	
			_author_id = author_id ;	
			_title = title ;	
			_description = description ;	
			_type = type ;	
			_allowcomment = allowcomment ;	
			_markprivate = markprivate ;	
			_body = body ;	
			_datecreated = datecreated ;	
			_datepublished = datepublished ;	
			_datemodified = datemodified ;	
			_islock = islock ;	
			_blogtype_id = blogtype_id ;	
		}
		
		public int  Blog_id
		{
			get
			{
				return _blog_id;
			}
			set
			{
				_blog_id=value;
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
			
		public string  Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title=value;
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
			
		public string  Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type=value;
			}				
		}
			
		public string  Allowcomment
		{
			get
			{
				return _allowcomment;
			}
			set
			{
				_allowcomment=value;
			}				
		}
			
		public string  Markprivate
		{
			get
			{
				return _markprivate;
			}
			set
			{
				_markprivate=value;
			}				
		}
			
		public string  Body
		{
			get
			{
				return _body;
			}
			set
			{
				_body=value;
			}				
		}
			
		public DateTime  Datecreated
		{
			get
			{
				return _datecreated;
			}
			set
			{
				_datecreated=value;
			}				
		}
			
		public DateTime  Datepublished
		{
			get
			{
				return _datepublished;
			}
			set
			{
				_datepublished=value;
			}				
		}
			
		public DateTime  Datemodified
		{
			get
			{
				return _datemodified;
			}
			set
			{
				_datemodified=value;
			}				
		}
			
		public string  Islock
		{
			get
			{
				return _islock;
			}
			set
			{
				_islock=value;
			}				
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
			
	}
}


