using System;
using Blog.Application.DTOs;
using MimeKit;

namespace Blog.Application.Services
{
	public interface IEmailService
	{
		public Task SendEmailAsync(string emailAdress, string body);
	}
}

