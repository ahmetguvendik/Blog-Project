using System;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Blog.Application.CQRS.Commands.User.SignOutUser
{
	public class SignOutUserCommandHandler : IRequestHandler<SignOutUserCommandRequest,SignOutUserCommandResponse>
	{
        private readonly SignInManager<AppUser> _signInManager;
		public SignOutUserCommandHandler(SignInManager<AppUser> signInManager)
		{
            _signInManager = signInManager;
		}

        public async Task<SignOutUserCommandResponse> Handle(SignOutUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return new SignOutUserCommandResponse();
        }
    }
}

