using System;
namespace Blog.Application.Repositories
{
	public interface IReadRepository<T> :IRepository<T> where T: Blog.Domain.Entities.Blog
    {
		IQueryable<T> GetAll();
        Task<T> GetById(string id);
    }
}

