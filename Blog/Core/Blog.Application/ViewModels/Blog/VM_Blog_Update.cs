using System;
namespace Blog.Application.ViewModels.Blog
{
	public class VM_Blog_Update
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
        public DateTime UpdatedTime { get; set; }
    }	
}

