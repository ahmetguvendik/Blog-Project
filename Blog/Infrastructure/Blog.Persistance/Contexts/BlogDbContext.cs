using System;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Entities;

namespace Blog.Persistance.Contexts
{
	public class BlogDbContext : DbContext
	{
		public BlogDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Blog.Domain.Entities.Blog> Blogs { get; set; }
	}	
}

