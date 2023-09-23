using System;
using Blog.Application.ViewModels.Blog;
using MediatR;

namespace Blog.Application.CQRS.Queries.Blog.UpdateGetByIdBlog
{
	public class UpdateGetbyIdBlogQueryRequest : IRequest<VM_Blog_Update>
    {
		public string Id { get; set; }	
	}
}

