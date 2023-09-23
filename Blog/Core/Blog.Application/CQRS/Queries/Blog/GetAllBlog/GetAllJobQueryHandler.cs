using System;
using Blog.Application.Repositories;
using Blog.Application.ViewModels.Blog;
using MediatR;

namespace Blog.Application.CQRS.Queries.Blog.GetAllJob
{
	public class GetAllJobQueryHandler : IRequestHandler<GetAllJobQueryRequest,IQueryable<Domain.Entities.Blog>>
	{
        private readonly IBlogReadRepository _blogReadRepository;
		public GetAllJobQueryHandler(IBlogReadRepository blogReadRepository)
		{
            _blogReadRepository = blogReadRepository;
		}

        public async Task<IQueryable<Domain.Entities.Blog>> Handle(GetAllJobQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _blogReadRepository.GetAll();
            return values;
        }
    }
}

