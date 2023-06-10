using System;
using Blog.Application.Repositories;
using MediatR;

namespace Blog.Application.Features.Queries.Blog.GetAllBlog
{
	public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQueryRequest,GetAllBlogQueryResponse>
	{
        private readonly IBlogReadRepository _readRepository;
 
        public GetAllBlogQueryHandler(IBlogReadRepository readRepository)
		{
            _readRepository = readRepository;
    
		}

        public async Task<GetAllBlogQueryResponse> Handle(GetAllBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blogs = await _readRepository.GetAll();
            
            return new GetAllBlogQueryResponse()
            {
                Blogs = blogs
            };
        }
    }
}

