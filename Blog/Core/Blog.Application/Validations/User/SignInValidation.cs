using System;
using Blog.Application.CQRS.Commands.User.LoginUser;
using Blog.Application.ViewModels.User;
using FluentValidation;

namespace Blog.Application.Validations.User
{
	public class SignInValidation : AbstractValidator<LoginUserCommandRequest>
	{
		public SignInValidation()
		{
            RuleFor(x => x.Username).NotEmpty().NotNull().WithMessage("Bos Birakilamaz").MaximumLength(60).MinimumLength(5).WithMessage("Lütfen ürün adını 5 ile 60 karakter arasında giriniz.");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Bos Birakilamaz").MaximumLength(60).MinimumLength(5).WithMessage("Lütfen ürün adını 5 ile 60 karakter arasında giriniz.");
        }
	}
}

