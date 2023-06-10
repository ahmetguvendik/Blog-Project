using System;
using MediatR;

namespace Blog.Application.Features.Commands.User.CreateUser
{
	public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
	{
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PhoneNumber { get; set; }
    }
}

