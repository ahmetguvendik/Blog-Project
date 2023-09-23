using System;
using Blog.Application.ViewModels.Blog;
using MediatR;

namespace Blog.Application.CQRS.Queries.Blog.GetAllJob
{
	public class GetAllJobQueryRequest : IRequest<IQueryable<Domain.Entities.Blog>>
	{
		
	}
}

