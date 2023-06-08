using System;
namespace Blog.Domain.Entities
{
	public class Blog
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime UpdatedTime { get; set; }	
	}	
}

