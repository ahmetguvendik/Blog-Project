using System;
using Blog.Application.Repositories;
using MediatR;

namespace Blog.Application.Features.Commands.Blog.RemoveBlog
{
	public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommandRequest,RemoveBlogCommandResponse>
	{
        private readonly IBlogWriteRepository _writeRepository;
		public RemoveBlogCommandHandler(IBlogWriteRepository writeRepository)
		{
            _writeRepository = writeRepository;
		}

        public async Task<RemoveBlogCommandResponse> Handle(RemoveBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _writeRepository.RemoveAsync(request.Id);
            await _writeRepository.SaveAsync();
            return new RemoveBlogCommandResponse();
        }
    }
}

