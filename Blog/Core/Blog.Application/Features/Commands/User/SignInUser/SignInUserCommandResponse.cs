using System;
using Blog.Application.DTOs;

namespace Blog.Application.Features.Commands.User.SignInUser
{
	public class SignInUserCommandResponse
	{
        public bool isSucceced { get; set; }
        public string Message { get; set; }
        public Token Token { get; set; }
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}

