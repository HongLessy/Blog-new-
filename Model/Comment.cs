///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System;

namespace Blog.Model
{
	public class CommentEntity
	{
		protected int _comment_id;
		protected string _author = String.Empty;
		protected int _blog_id;
		protected string _ip = String.Empty;
		protected DateTime _datecreated;
		protected DateTime _datemodified;
		protected string _body = String.Empty;
		protected string _islock = String.Empty;
	
		public CommentEntity()
		{
			
		}
		
		public CommentEntity(int comment_id,string author,int blog_id,string ip,DateTime datecreated,DateTime datemodified,string body,string islock)
		{
			_comment_id = comment_id ;	
			_author = author ;	
			_blog_id = blog_id ;	
			_ip = ip ;	
			_datecreated = datecreated ;	
			_datemodified = datemodified ;	
			_body = body ;	
			_islock = islock ;	
		}
		
		public int  Comment_id
		{
			get
			{
				return _comment_id;
			}
			set
			{
				_comment_id=value;
			}				
		}
			
		public string  Author
		{
			get
			{
				return _author;
			}
			set
			{
				_author=value;
			}				
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
			
		public string  Ip
		{
			get
			{
				return _ip;
			}
			set
			{
				_ip=value;
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
			
	}
}


