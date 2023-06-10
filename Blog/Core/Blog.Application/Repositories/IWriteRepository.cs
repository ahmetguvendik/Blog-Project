using System;
namespace Blog.Application.Repositories
{
	public interface IWriteRepository<T> :IRepository<T> where T: Blog.Domain.Entities.Blog
    {
		Task AddBlogAsync(T model);
		Task UpdateBlogAsync(T model);
		bool Remove(T model);
		Task<bool> RemoveAsync(string id);
		Task SaveAsync();
	}
}

