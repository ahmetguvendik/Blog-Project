using System;
using Blog.Application.Repositories;
using MediatR;

namespace Blog.Application.CQRS.Commands.Blog.CreateBlog
{
	public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommandRequest,CreateBlogCommandResponse>
	{
        private readonly IBlogWriteRepository _blogWriteRepository;
		public CreateBlogCommandHandler(IBlogWriteRepository blogWriteRepository)
		{
            _blogWriteRepository = blogWriteRepository;
		}

        public async Task<CreateBlogCommandResponse> Handle(CreateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = new Domain.Entities.Blog();
            blog.Id = Guid.NewGuid().ToString();
            blog.Title = request.Title;
            blog.Description = request.Description;
            blog.CreatedTime = DateTime.UtcNow;
            await _blogWriteRepository.AddBlogAsync(blog);
            await _blogWriteRepository.SaveAsync();
            return new CreateBlogCommandResponse()
            {
                Description = request.Description,
                Title = request.Title
            };
        }
    }
}

