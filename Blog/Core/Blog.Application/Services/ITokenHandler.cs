using System;
using Blog.Application.DTOs;
using Blog.Domain.Entities;

namespace Blog.Application.Services
{
	public interface ITokenHandler
	{
		public Token CreateAccessToken(AppUser user);
	}	
}

