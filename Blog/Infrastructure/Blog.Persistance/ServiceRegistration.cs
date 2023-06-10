using System;
using Blog.Application.Repositories;
using Blog.Domain.Entities;
using Blog.Persistance.Contexts;
using Blog.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Persistance
{
	public static class ServiceRegistration
	{
        public static void AddPersistanceService(this IServiceCollection collection)
		{
			collection.AddDbContext<BlogDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=BlogDB;"));
            collection.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogDbContext>();
            collection.AddScoped<IBlogReadRepository, BlogReadRepository>();
			collection.AddScoped<IBlogWriteRepository, BlogWriteRepository>();
		}
	}
}

