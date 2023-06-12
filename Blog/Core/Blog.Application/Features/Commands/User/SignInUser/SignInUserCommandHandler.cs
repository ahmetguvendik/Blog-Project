using System;
using Blog.Application.Services;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Blog.Application.Features.Commands.User.SignInUser
{
	public class SignInUserCommandHandler : IRequestHandler<SignInUserCommandRequest,SignInUserCommandResponse>
	{
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _handler;

        public SignInUserCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenHandler handler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _handler = handler;
        }
       
        public async Task<SignInUserCommandResponse> Handle(SignInUserCommandRequest request, CancellationToken cancellationToken)
        {
                var user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
                  
                }
          
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (result.Succeeded)
                {
                    var token = _handler.CreateAccessToken(user);
                    return new SignInUserCommandResponse()
                    {
                        isSucceced = result.Succeeded,
                        Message = "Giris Yapildi",
                        Token = token
                    };
                }

                else
                {
                    return new SignInUserCommandResponse()
                    {
                        isSucceced = result.Succeeded,
                        Message = "Giris Yaparken Bir Hata Olustu",
                        Token = null

                    };
                }
            }

            
    }
}

