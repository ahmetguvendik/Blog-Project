using System;
using Blog.Application.Repositories;
using Blog.Application.ViewModels.Blog;
using MediatR;

namespace Blog.Application.CQRS.Queries.Blog.UpdateGetByIdBlog
{
	public class UpdateGetByIdBlogQueryHandler : IRequestHandler<UpdateGetbyIdBlogQueryRequest, VM_Blog_Update>
	{
        private readonly IBlogReadRepository _blogReadRepository;
		public UpdateGetByIdBlogQueryHandler(IBlogReadRepository blogReadRepository)
		{
            _blogReadRepository = blogReadRepository;
		}

        public async Task<VM_Blog_Update> Handle(UpdateGetbyIdBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blog = await _blogReadRepository.GetById(request.Id);
            VM_Blog_Update blogMapper = new VM_Blog_Update();
            blogMapper.Title = blog.Title;
            blogMapper.Description = blog.Description;
            return blogMapper;
        }
    }
}

