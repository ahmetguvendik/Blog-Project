using System;
namespace Blog.Application.Features.Queries.Blog.GetAllBlog
{
	public class GetAllBlogQueryResponse
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

    }
}

