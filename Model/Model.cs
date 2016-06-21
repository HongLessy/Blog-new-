///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System;

namespace Blog.Model
{
	public class ModelEntity
	{
		protected int _model_id;
		protected string _name = String.Empty;
		protected string _path = String.Empty;
	
		public ModelEntity()
		{
			
		}
		
		public ModelEntity(int model_id,string name,string path)
		{
			_model_id = model_id ;	
			_name = name ;	
			_path = path ;	
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
			
		public string  Path
		{
			get
			{
				return _path;
			}
			set
			{
				_path=value;
			}				
		}
			
	}
}


