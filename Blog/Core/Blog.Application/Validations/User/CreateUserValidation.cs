using System;
using Blog.Application.ViewModels.User;
using FluentValidation;

namespace Blog.Application.Validations.User
{
	public class CreateUserValidation : AbstractValidator<VM_User_Create>
	{
		public CreateUserValidation()
		{
			RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Bos Birakilamaz").MaximumLength(60).MinimumLength(5).WithMessage("Lütfen ürün adını 5 ile 60 karakter arasında giriniz.");
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("Bos Birakilamaz").MaximumLength(60).MinimumLength(5).WithMessage("Lütfen ürün adını 5 ile 60 karakter arasında giriniz.");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Bos Birakilamaz").MaximumLength(60).MinimumLength(5).WithMessage("Lütfen ürün adını 5 ile 60 karakter arasında giriniz.");
            
        }
    }
}

