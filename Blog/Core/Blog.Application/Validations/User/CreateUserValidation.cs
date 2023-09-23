using System;
using Blog.Application.CQRS.Commands.User.CreateUser;
using Blog.Application.ViewModels.User;
using FluentValidation;

namespace Blog.Application.Validations.User
{
	public class CreateUserValidation : AbstractValidator<CreateUserCommandRequest>
	{
		public CreateUserValidation()
		{
			RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Bos Birakilamaz").MaximumLength(60).MinimumLength(5).WithMessage("Lütfen ürün adını 5 ile 60 karakter arasında giriniz.");
            RuleFor(x => x.Username).NotEmpty().NotNull().WithMessage("Bos Birakilamaz").MaximumLength(60).MinimumLength(5).WithMessage("Lütfen ürün adını 5 ile 60 karakter arasında giriniz.");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Bos Birakilamaz").MaximumLength(60).MinimumLength(5).WithMessage("Lütfen ürün adını 5 ile 60 karakter arasında giriniz.");
            
        }
    }
}

