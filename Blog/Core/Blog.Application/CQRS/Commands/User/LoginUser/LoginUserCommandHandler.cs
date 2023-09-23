using System;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Blog.Application.CQRS.Commands.User.LoginUser
{
	public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest,LoginUserCommandResponse>
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
		public LoginUserCommandHandler(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
		{
            _userManager = userManager;
            _signInManager = signInManager;
		}

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByNameAsync(request.Username);

            var response = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            if (response.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(appUser);
                //   var userId = await _userManager.FindByIdAsync(appUser.Id.ToString());
                if (role.Contains("Member"))
                {
                    return new LoginUserCommandResponse()
                    {
                        Password = request.Password,
                        Username = request.Username,
                        Role = "Member"
                    };
                }
                else if (role.Contains("Admin"))
                {
                    return new LoginUserCommandResponse()
                    {
                        Password = request.Password,
                        Username = request.Username,
                        Role = "Admin"
                    };
                }
                //   var user = await _userManager.FindByNameAsync(model.Username);

            }

            return new LoginUserCommandResponse()
            {
                Password = request.Password,
                Username = request.Username,
                Role = ""
            };
        }
    }
}

