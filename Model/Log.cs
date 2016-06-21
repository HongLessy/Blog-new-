///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System;

namespace Blog.Model
{
	public class LogEntity
	{
		protected int _id;
		protected int _author_id;
		protected DateTime _date;
		protected string _opevent = String.Empty;
	
		public LogEntity()
		{
			
		}
		
		public LogEntity(int id,int author_id,DateTime date,string opevent)
		{
			_id = id ;	
			_author_id = author_id ;	
			_date = date ;	
			_opevent = opevent ;	
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
			
		public DateTime  Date
		{
			get
			{
				return _date;
			}
			set
			{
				_date=value;
			}				
		}
			
		public string  Opevent
		{
			get
			{
				return _opevent;
			}
			set
			{
				_opevent=value;
			}				
		}
			
	}
}


