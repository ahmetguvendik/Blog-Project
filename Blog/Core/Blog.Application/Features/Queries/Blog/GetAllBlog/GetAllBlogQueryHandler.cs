using System;
using Blog.Application.Repositories;
using MediatR;

namespace Blog.Application.Features.Queries.Blog.GetAllBlog
{
	public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQueryRequest,IQueryable<Domain.Entities.Blog>>
	{
        private readonly IBlogReadRepository _readRepository;
 
        public GetAllBlogQueryHandler(IBlogReadRepository readRepository)
		{
            _readRepository = readRepository;
    
		}

        public async Task<IQueryable<Domain.Entities.Blog>> Handle(GetAllBlogQueryRequest request, CancellationToken cancellationToken)
        {
            return _readRepository.GetAll();
        }
    }
}

