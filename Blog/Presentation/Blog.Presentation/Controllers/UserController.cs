using Blog.Application.CQRS.Commands.User.CreateUser;
using Blog.Application.CQRS.Commands.User.LoginUser;
using Blog.Application.CQRS.Commands.User.ResetPassword;
using Blog.Application.CQRS.Commands.User.SignOutUser;
using Blog.Application.Services;
using Blog.Application.ViewModels.User;
using Blog.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IValidator<CreateUserCommandRequest> _userValidator;
        private readonly IValidator<LoginUserCommandRequest> _singInUserValidator;
        private readonly IValidator<ResetPasswordCommandRequest> _resetPasswordValidator;
        private readonly IEmailService _emailService;
        private readonly IMediator _mediator;

        public UserController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager, IValidator<CreateUserCommandRequest> userValidator, IValidator<LoginUserCommandRequest> singInUserValidator, IEmailService emailService, IValidator<ResetPasswordCommandRequest> resetPasswordValidator,IMediator mediator)
        {
    
            _userManager = userManager;
            _roleManager = roleManager;
            _userValidator = userValidator;
            _singInUserValidator = singInUserValidator;
            _emailService = emailService;
            _resetPasswordValidator = resetPasswordValidator;
            _mediator = mediator;
       
        }
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest model )
        {
            try
            {
                _userValidator.ValidateAndThrow(model);
                await _mediator.Send(model);
             
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>SignIn(LoginUserCommandRequest model)
        {
            try
            {
                _singInUserValidator.ValidateAndThrow(model);
                if (ModelState.IsValid)
                {
                   var response =  await _mediator.Send(model);
                    if(response.Role == "Member")
                    {
                        return RedirectToAction("GetBlogTitle", "MemberBlog");
                    }

                    else if(response.Role == "Admin")
                    {
                        return RedirectToAction("GetBlog", "Blog");
                    }

                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
           
            return View();
        }

        public async Task<IActionResult> SignOut(SignOutUserCommandRequest model)
        {
            await _mediator.Send(model);
            return RedirectToAction("SignIn", "User");
        }

        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommandRequest resetPassword)
        {
            try
            {
                _resetPasswordValidator.ValidateAndThrow(resetPassword);
                await _mediator.Send(resetPassword);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
          

            return View();
         }
      

        public IActionResult ResetPasswordForEmail()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordForEmail(ResetPassword resetPassword)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(resetPassword.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var link = Url.Action(nameof(ResetPassword), "User", new
                    {
                        token,
                        email = user.Email
                    },
                    Request.Scheme
                    );

                    await _emailService.SendEmailAsync(resetPassword.Email, link);
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }
    }
}

