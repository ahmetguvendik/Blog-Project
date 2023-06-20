using System;
using Blog.Application.Repositories;
using Blog.Application.Services;
using Blog.Domain.Entities;
using Blog.Persistance.Contexts;
using Blog.Persistance.Repositories;
using Blog.Persistance.Services;
using Microsoft.AspNetCore.Identity;
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
            collection.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogDbContext>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider); ;
            collection.AddScoped<IBlogReadRepository, BlogReadRepository>();
			collection.AddScoped<IBlogWriteRepository, BlogWriteRepository>();
            collection.AddScoped<ITokenHandler, TokenHandler>();
		
        }
	}
}

