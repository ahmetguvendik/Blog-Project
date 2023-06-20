﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.ViewModels.User
{
	public class ResetPassword
	{

		public string Password { get; set; }

		[Compare("Password",ErrorMessage = "Sifreler Eslesmiyor")]
		public string ConfirmPassword { get; set; }

		public string Email { get; set; }

		public string Token { get; set; }	
	}	
}

