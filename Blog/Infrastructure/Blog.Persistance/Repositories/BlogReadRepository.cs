using System;
using Blog.Application.Repositories;
using Blog.Persistance.Contexts;

namespace Blog.Persistance.Repositories
{
    public class BlogReadRepository : ReadRepository<Blog.Domain.Entities.Blog>, IBlogReadRepository
    {
        public BlogReadRepository(BlogDbContext context) : base(context)
        {
        }
    }
}

