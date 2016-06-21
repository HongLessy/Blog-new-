///
//创建项目
//创建人：HonLessy
//创建时间2016年6月21日
///

using System;

namespace Blog.Model
{
	public class Blog_TagEntity
	{
		protected int _blog_tag_id;
		protected int _tag_id;
		protected int _blog_id;
	
		public Blog_TagEntity()
		{
			
		}
		
		public Blog_TagEntity(int blog_tag_id,int tag_id,int blog_id)
		{
			_blog_tag_id = blog_tag_id ;	
			_tag_id = tag_id ;	
			_blog_id = blog_id ;	
		}
		
		public int  Blog_tag_id
		{
			get
			{
				return _blog_tag_id;
			}
			set
			{
				_blog_tag_id=value;
			}				
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
			
	}
}


