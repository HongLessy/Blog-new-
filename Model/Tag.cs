///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System;

namespace Blog.Model
{
	public class TagEntity
	{
		protected int _tag_id;
		protected string _tagName = String.Empty;
	
		public TagEntity()
		{
			
		}
		
		public TagEntity(int tag_id,string tagName)
		{
			_tag_id = tag_id ;	
			_tagName = tagName ;	
		}
		
		public int  Tag_id
		{
			get
			{
				return _tag_id;
			}
			set
			{
				_tag_id=value;
			}				
		}
			
		public string  TagName
		{
			get
			{
				return _tagName;
			}
			set
			{
				_tagName=value;
			}				
		}
			
	}
}


