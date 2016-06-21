///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System;

namespace Blog.Model
{
	public class FileEntity
	{
		protected int _id;
		protected string _filename = String.Empty;
		protected string _mime = String.Empty;
		protected byte[] _filecontent;
		protected int _author_id;
	
		public FileEntity()
		{
			
		}
		
		public FileEntity(int id,string filename,string mime,byte[] filecontent,int author_id)
		{
			_id = id ;	
			_filename = filename ;	
			_mime = mime ;	
			_filecontent = filecontent ;	
			_author_id = author_id ;	
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
			
		public string  Filename
		{
			get
			{
				return _filename;
			}
			set
			{
				_filename=value;
			}				
		}
			
		public string  Mime
		{
			get
			{
				return _mime;
			}
			set
			{
				_mime=value;
			}				
		}
			
		public byte[]  Filecontent
		{
			get
			{
				return _filecontent;
			}
			set
			{
				_filecontent=value;
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


