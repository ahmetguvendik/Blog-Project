using System;
using MediatR;

namespace Blog.Application.CQRS.Commands.User.LoginUser
{
	public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
	{
		public string Username { get; set; }
		public string Password { get; set; }	
	}
}

