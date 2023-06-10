using System;
using Blog.Application.Repositories;
using MediatR;

namespace Blog.Application.Features.Commands.Blog.CreateBlog
{
	public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommandRequest,CreateBlogCommandResponse>
	{
        private readonly IBlogWriteRepository _writeRepository;
		public CreateBlogCommandHandler(IBlogWriteRepository writeRepository)
		{
            _writeRepository = writeRepository;
		}

        public async Task<CreateBlogCommandResponse> Handle(CreateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = new Domain.Entities.Blog();
            blog.CreatedTime = DateTime.UtcNow;
            blog.UpdatedTime = DateTime.UtcNow;
            blog.Id = Guid.NewGuid().ToString();
            blog.Title = request.Title;
            blog.Description = request.Description;
            await _writeRepository.AddBlogAsync(blog);
            await _writeRepository.SaveAsync();
            return new CreateBlogCommandResponse();
            
        }
    }
}

