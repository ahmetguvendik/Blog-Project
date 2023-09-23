using System;
using MediatR;

namespace Blog.Application.CQRS.Commands.Blog.RemoveBlog
{
	public class RemoveBlogCommandRequest : IRequest<RemoveBlogCommandResponse>
	{
		public string Id { get; set; }
	}
}

