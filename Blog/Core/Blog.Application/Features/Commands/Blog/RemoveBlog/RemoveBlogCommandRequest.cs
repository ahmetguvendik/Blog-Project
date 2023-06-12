using System;
using MediatR;

namespace Blog.Application.Features.Commands.Blog.RemoveBlog
{
	public class RemoveBlogCommandRequest : IRequest<RemoveBlogCommandResponse>
	{
		public string Id { get; set; }		
	}
}

