using System;
using Blog.Application.Repositories;
using Blog.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : Blog.Domain.Entities.Blog
    {
        private readonly BlogDbContext _context;
        public ReadRepository(BlogDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public async Task<T> GetById(string id)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

