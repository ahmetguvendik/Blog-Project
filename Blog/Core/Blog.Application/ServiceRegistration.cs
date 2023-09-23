using System;
using Blog.Application.CQRS.Commands.User.CreateUser;
using Blog.Application.CQRS.Commands.User.LoginUser;
using Blog.Application.CQRS.Commands.User.ResetPassword;
using Blog.Application.Repositories;
using Blog.Application.Validations.User;
using Blog.Application.ViewModels.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection collection)
        {
            collection.AddTransient<IValidator<CreateUserCommandRequest>, CreateUserValidation>();
            collection.AddTransient<IValidator<LoginUserCommandRequest>, SignInValidation>();
            collection.AddTransient<IValidator<ResetPasswordCommandRequest>, ResetPasswordValidation>();
        }
    }
}

