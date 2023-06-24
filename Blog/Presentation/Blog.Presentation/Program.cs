using Blog.Persistance;
using Blog.Application;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Serilog;
using Serilog.Sinks.PostgreSQL;
using Microsoft.AspNetCore.Authorization;
using Blog.Presentation.Controllers;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Blog.Persistance.Contexts;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using Blog.Application.ViewModels.User;
using Blog.Application.Validations.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(x => x.Filters.Add<BlogController>());
builder.Services.AddControllersWithViews();
builder.Services.AddPersistanceService();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Blog.Application.ServiceRegistration).GetTypeInfo().Assembly));
builder.Services.AddApplicationService();
builder.Services.AddCors();




builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.HttpOnly = true;
    opt.Cookie.Name = "BlogCoolie";
    opt.AccessDeniedPath = new PathString("/Home/AccesDenided");
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromMinutes(15));  
Logger log = new LoggerConfiguration()
//    .WriteTo.Console()
 //   .WriteTo.File("logs/log.txt")
    .WriteTo.PostgreSQL(builder.Configuration["ConnectionStrings:Local"], "Logs", needAutoCreateTable: true, columnOptions: new Dictionary<string, ColumnWriterBase>
    {
        {"message",new RenderedMessageColumnWriter() },
        {"messageTemp",new MessageTemplateColumnWriter() },
        {"level",new LevelColumnWriter() },
        {"timeStamp",new TimestampColumnWriter() },
        {"exeption",new ExceptionColumnWriter() },
        {"logEvent",new LogEventSerializedColumnWriter() },
      
    })
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseCors();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

