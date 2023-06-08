using System;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Repositories
{
	public interface IRepository<T> where T : Blog.Domain.Entities.Blog
    {
		DbSet<T> Table { get; }
	}
}

