using System;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.DTOs
{
	public class MailRequest
	{
		public string toEmail { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public List<IFormFile> Attachments { get; set; }	
	}	
}

