using System;
using Blog.Application.Repositories;
using MediatR;

namespace Blog.Application.CQRS.Queries.Blog.GetByIdBlog
{
	public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQueryRequest,Domain.Entities.Blog>
	{
        private readonly IBlogReadRepository _blogReadRepository;
		public GetByIdBlogQueryHandler(IBlogReadRepository blogReadRepository)
		{
            _blogReadRepository = blogReadRepository;
		}

        public Task<Domain.Entities.Blog> Handle(GetByIdBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blog = _blogReadRepository.GetById(request.Id);
            return blog;
        }
    }
}

