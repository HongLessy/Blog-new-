///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System;

namespace Blog.Model
{
	public class RoleEntity
	{
		protected int _role_id;
		protected string _name = String.Empty;
	
		public RoleEntity()
		{
			
		}
		
		public RoleEntity(int role_id,string name)
		{
			_role_id = role_id ;	
			_name = name ;	
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
			
	}
}


