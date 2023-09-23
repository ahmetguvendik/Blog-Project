using System;
namespace Blog.Application.CQRS.Commands.Blog.CreateBlog
{
	public class CreateBlogCommandResponse
	{
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

