using System;
using Blog.Application.Repositories;
using MediatR;

namespace Blog.Application.Features.Queries.Blog.GetByIdBlog
{
    public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQueryRequest, GetByIdBlogQueryResponse>
    {
        private readonly IBlogReadRepository _readRepository;
        public GetByIdBlogQueryHandler(IBlogReadRepository readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<GetByIdBlogQueryResponse> Handle(GetByIdBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await  _readRepository.GetById(request.Id);
            return new GetByIdBlogQueryResponse();
          
        }
    }
}

