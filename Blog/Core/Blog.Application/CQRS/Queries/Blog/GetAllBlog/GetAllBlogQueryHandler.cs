using System;
using Blog.Application.Repositories;
using MediatR;

namespace Blog.Application.CQRS.Queries.Blog.GetAllBlog
{
	public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQueryRequest,IQueryable<Domain.Entities.Blog>>
	{
        private readonly IBlogReadRepository _blogReadRepository;
		public GetAllBlogQueryHandler(IBlogReadRepository blogReadRepository)
		{
            _blogReadRepository = blogReadRepository;
		}

        public async Task<IQueryable<Domain.Entities.Blog>> Handle(GetAllBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _blogReadRepository.GetAll();
            return values;
        }
    }
}

