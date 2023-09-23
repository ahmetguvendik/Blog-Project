using System;
namespace Blog.Application.CQRS.Commands.Blog.UpdateBlog
{
	public class UpdateBlogCommandResponse
	{
        public string Description { get; set; }
        public string Title { get; set; }
    }
}

