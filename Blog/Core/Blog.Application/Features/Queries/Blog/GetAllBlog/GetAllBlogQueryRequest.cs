using System;
using MediatR;

namespace Blog.Application.Features.Queries.Blog.GetAllBlog
{
	public class GetAllBlogQueryRequest : IRequest<IQueryable<Domain.Entities.Blog>>
	{
		
	}
}

