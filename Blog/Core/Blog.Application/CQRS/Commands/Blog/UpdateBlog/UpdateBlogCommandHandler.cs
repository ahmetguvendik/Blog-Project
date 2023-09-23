using System;
using Blog.Application.Repositories;
using MediatR;

namespace Blog.Application.CQRS.Commands.Blog.UpdateBlog
{
	public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommandRequest,UpdateBlogCommandResponse>
	{
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly IBlogWriteRepository _blogWriteRepository;
		public UpdateBlogCommandHandler(IBlogReadRepository blogReadRepository,IBlogWriteRepository blogWriteRepository)
		{
            _blogReadRepository = blogReadRepository;
            _blogWriteRepository = blogWriteRepository;
		}

        public async Task<UpdateBlogCommandResponse> Handle(UpdateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = await _blogReadRepository.GetById(request.Id);
            blog.Title = request.Title;
            blog.Description = request.Description;
            blog.UpdatedTime = DateTime.UtcNow;
            await _blogWriteRepository.SaveAsync();
            return new UpdateBlogCommandResponse()
            {
                Title = request.Title,
                Description = request.Description
            };
        }
    }
}

