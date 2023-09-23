using System;
using MediatR;

namespace Blog.Application.CQRS.Commands.Blog.CreateBlog
{
	public class CreateBlogCommandRequest : IRequest<CreateBlogCommandResponse>
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}
}

