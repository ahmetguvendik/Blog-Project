using System;
namespace Blog.Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandResponse
	{
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}

