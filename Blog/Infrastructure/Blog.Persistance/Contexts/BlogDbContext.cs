using System;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Blog.Persistance.Contexts
{
	public class BlogDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
		public BlogDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Blog.Domain.Entities.Blog> Blogs { get; set; }
	}	
}

