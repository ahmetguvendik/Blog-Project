using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.ViewModels.User
{
	public class VM_User_SignIn
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
	}	
}

