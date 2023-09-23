using System;
using MediatR;

namespace Blog.Application.CQRS.Queries.Blog.GetByIdBlog
{
	public class GetByIdBlogQueryRequest : IRequest<Domain.Entities.Blog>
	{
		public string Id { get; set; }	
	}
}

