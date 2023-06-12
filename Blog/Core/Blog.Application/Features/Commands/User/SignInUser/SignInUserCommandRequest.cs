using System;
using MediatR;

namespace Blog.Application.Features.Commands.User.SignInUser
{
	public class SignInUserCommandRequest : IRequest<SignInUserCommandResponse>
	{
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}

