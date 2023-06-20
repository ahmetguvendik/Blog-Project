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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(x => x.Filters.Add<BlogController>());
builder.Services.AddControllersWithViews();
builder.Services.AddPersistanceService();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Blog.Application.ServiceRegistration).GetTypeInfo().Assembly));


builder.Services.AddCors();

builder.Services.AddAuthentication(opt => {
    //opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.SaveToken = true;
    opt.TokenValidationParameters = new()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.Now : false,
        NameClaimType = ClaimTypes.Name
    };
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromMinutes(15));  
Logger log = new LoggerConfiguration()
//    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
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

