using System;
namespace Blog.Application.DTOs
{
	public class Token
	{
		public string AccessToken { get; set; }
        public DateTime ExpinationTime { get; set; }
    }	
}

