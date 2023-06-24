using System;
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
            collection.AddTransient<IValidator<VM_User_Create>, CreateUserValidation>();
            collection.AddTransient<IValidator<VM_User_SignIn>, SignInValidation>();
            collection.AddTransient<IValidator<ResetPassword>, ResetPasswordValidation>();
        }
    }
}

