using System;
namespace Blog.Application.CQRS.Commands.User.LoginUser
{
	public class LoginUserCommandResponse
	{
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }  
    }
}

