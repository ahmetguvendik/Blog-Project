using System;
namespace Blog.Application.Features.Commands.User.CreateUser
{
	public class CreateUserCommandResponse
	{
		public string Message { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PhoneNumber { get; set; }
    }
}

