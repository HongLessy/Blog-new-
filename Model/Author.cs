///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System;

namespace Blog.Model
{
	public class AuthorEntity
	{
		protected int _author_id;
		protected string _username = String.Empty;
		protected string _password = String.Empty;
		protected int _role_id;
		protected string _islock = String.Empty;
		protected string _email = String.Empty;
	
		public AuthorEntity()
		{
			
		}
		
		public AuthorEntity(int author_id,string username,string password,int role_id,string islock,string email)
		{
			_author_id = author_id ;	
			_username = username ;	
			_password = password ;	
			_role_id = role_id ;	
			_islock = islock ;	
			_email = email ;	
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
			
		public string  Username
		{
			get
			{
				return _username;
			}
			set
			{
				_username=value;
			}				
		}
			
		public string  Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password=value;
			}				
		}
			
		public int  Role_id
		{
			get
			{
				return _role_id;
			}
			set
			{
				_role_id=value;
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
			
		public string  Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email=value;
			}				
		}
			
	}
}


