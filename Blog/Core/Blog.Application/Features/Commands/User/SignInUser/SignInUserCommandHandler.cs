using System;
using MediatR;

namespace Blog.Application.Features.Commands.User.SignInUser
{
	public class SignInUserCommandHandler : IRequestHandler<SignInUserCommandRequest,SignInUserCommandResponse>
	{
		public SignInUserCommandHandler()
		{
		}

        public Task<SignInUserCommandResponse> Handle(SignInUserCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

