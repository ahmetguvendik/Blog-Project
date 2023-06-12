using System;
using MediatR;

namespace Blog.Application.Features.Queries.Blog.GetByIdBlog
{
	public class GetByIdBlogQueryRequest : IRequest<GetByIdBlogQueryResponse>
	{
		public string Id { get; set; }		
	}
}

