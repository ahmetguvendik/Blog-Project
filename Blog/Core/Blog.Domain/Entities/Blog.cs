using System;
namespace Blog.Domain.Entities
{
	public class Blog
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime UpdatedTime { get; set; }	
	}	
}

