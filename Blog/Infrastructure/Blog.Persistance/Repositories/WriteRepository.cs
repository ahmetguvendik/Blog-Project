using System;
using Blog.Application.Repositories;
using Blog.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Blog.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : Blog.Domain.Entities.Blog
    {
        private readonly BlogDbContext _context;
        public WriteRepository(BlogDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task AddBlogAsync(T model)
        {
            await Table.AddAsync(model);
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityState = Table.Remove(model);
            return entityState.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
          
            T model = await Table.FirstOrDefaultAsync(x => x.Id == id);
            return Remove(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateBlogAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}

