using System;
using Blog.Application.Repositories;
using MediatR;

namespace Blog.Application.CQRS.Commands.Blog.RemoveBlog
{
	public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommandRequest,RemoveBlogCommandResponse>
	{
        private readonly IBlogWriteRepository _blogWriteRepository;
		public RemoveBlogCommandHandler(IBlogWriteRepository blogWriteRepository)
		{
            _blogWriteRepository = blogWriteRepository;
		}

        public async Task<RemoveBlogCommandResponse> Handle(RemoveBlogCommandRequest request, CancellationToken cancellationToken)
        {
            await _blogWriteRepository.RemoveAsync(request.Id);
            await _blogWriteRepository.SaveAsync();
            return new RemoveBlogCommandResponse();
        }
    }
}

