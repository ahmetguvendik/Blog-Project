using System;
using Blog.Application.Repositories;
using Blog.Persistance.Contexts;

namespace Blog.Persistance.Repositories
{
	public class BlogWriteRepository : WriteRepository<Blog.Domain.Entities.Blog>,IBlogWriteRepository
	{
        public BlogWriteRepository(BlogDbContext context) : base(context)
        {

        }
    }
}

