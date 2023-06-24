using System;
using Blog.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Blog.Persistance
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<BlogDbContext>
    {
        private readonly IConfiguration _configuration;
        public DesignTimeDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public BlogDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<BlogDbContext> dbContextOptions = new();
            dbContextOptions.UseNpgsql(_configuration["ConnectionStrings:Local"]);
            return new(dbContextOptions.Options);
        }
    }
}

