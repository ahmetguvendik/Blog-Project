using System;
using MediatR;

namespace Blog.Application.CQRS.Commands.Blog.UpdateBlog
{
	public class UpdateBlogCommandRequest : IRequest<UpdateBlogCommandResponse>
	{
		public string Id { get; set; }
		public string Description { get; set; }
		public string Title { get; set; }
	}

}

