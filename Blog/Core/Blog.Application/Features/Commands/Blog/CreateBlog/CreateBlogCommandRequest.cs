using System;
using MediatR;

namespace Blog.Application.Features.Commands.Blog.CreateBlog
{
	public class CreateBlogCommandRequest : IRequest<CreateBlogCommandResponse>
	{
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}

