using System;
using Blog.Application.CQRS.Commands.User.ResetPassword;
using Blog.Application.ViewModels.User;
using FluentValidation;

namespace Blog.Application.Validations.User
{
	public class ResetPasswordValidation : AbstractValidator<ResetPasswordCommandRequest>
    {
	
		public ResetPasswordValidation()
		{
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Bos Birakilamaz").MaximumLength(60).MinimumLength(5).WithMessage("Lütfen Email adresini 5 ile 60 karakter arasında giriniz.");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Bos Birakilamaz").MaximumLength(60).MinimumLength(5).WithMessage("Lütfen Sifrenizi 5 ile 60 karakter arasında giriniz.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().NotNull().WithMessage("Bos Birakilamaz").MaximumLength(60).MinimumLength(5).WithMessage("Lütfen Sifrenizi 5 ile 60 karakter arasında giriniz.");
        }
	}
}

