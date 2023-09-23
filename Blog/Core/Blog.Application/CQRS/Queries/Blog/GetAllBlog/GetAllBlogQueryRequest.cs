using System;
using MediatR;

namespace Blog.Application.CQRS.Queries.Blog.GetAllBlog
{
	public class GetAllBlogQueryRequest : IRequest<IQueryable<Domain.Entities.Blog>>
	{
		
	}
}

