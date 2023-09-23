using System;
using Blog.Application.ViewModels.User;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Blog.Application.CQRS.Commands.User.ResetPassword
{
	public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommandRequest,ResetPasswordCommandResponse>
	{
        private readonly UserManager<AppUser> _userManager;
		public ResetPasswordCommandHandler(UserManager<AppUser> userManager)
		{
            _userManager = userManager;
		}

        public async Task<ResetPasswordCommandResponse> Handle(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var resetResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
                if (resetResult.Succeeded)
                {
                    return new ResetPasswordCommandResponse()
                    {
                        Email = request.Email,
                        ConfirmPassword = request.ConfirmPassword,
                        Password = request.Password,
                        Token = request.Token
                    };
                }

            }
            return new ResetPasswordCommandResponse();
        }
    }
}

