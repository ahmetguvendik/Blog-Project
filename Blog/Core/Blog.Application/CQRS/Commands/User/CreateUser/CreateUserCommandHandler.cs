using System;
using Blog.Application.ViewModels.User;
using Blog.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Blog.Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public CreateUserCommandHandler(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
		{
            _roleManager = roleManager;
            _userManager = userManager;

        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var appUser = new AppUser();
            appUser.Id = Guid.NewGuid().ToString();
            appUser.Email = request.Email;
            appUser.UserName = request.Username;
            appUser.PhoneNumber = request.PhoneNumber;
            var response = await _userManager.CreateAsync(appUser, request.Password);
            if (response.Succeeded)
            {
                var role = await _roleManager.FindByNameAsync("Member");
                if (role == null)
                {
                    var appRole = new AppRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Member"
                    };
                    await _roleManager.CreateAsync(appRole);
                }

                await _userManager.AddToRoleAsync(appUser, "Member");
            }

            return new CreateUserCommandResponse()
            {
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Username = request.Username
            };
        }
    }
}

