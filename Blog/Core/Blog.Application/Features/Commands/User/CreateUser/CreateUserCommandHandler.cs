using System;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Blog.Application.Features.Commands.User.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
	{
        private readonly UserManager<AppUser> _userManager;
		public CreateUserCommandHandler(UserManager<AppUser> userManager)
		{
            _userManager = userManager;
		}

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = new AppUser();
            user.Id = Guid.NewGuid().ToString();
            user.Email = request.Email;
            user.UserName = request.UserName;
            user.PhoneNumber = request.PhoneNumber;
            var identityResult = await _userManager.CreateAsync(user, request.Password);
            if (identityResult.Succeeded)
            {
                return new CreateUserCommandResponse()
                {
                    Message = "Kayit Olma Basarili"
                };

            }
            else
            {
                return new CreateUserCommandResponse()
                {
                    Message = "Basarisiz"
                };
            }
        }
    }
}

