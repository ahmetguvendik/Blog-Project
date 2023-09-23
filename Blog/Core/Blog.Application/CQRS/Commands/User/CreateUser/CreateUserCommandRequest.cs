using System;
using MediatR;

namespace Blog.Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
	}
}

