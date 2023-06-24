using Blog.Application.Services;
using Blog.Application.ViewModels.User;
using Blog.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IValidator<VM_User_Create> _userValidator;
        private readonly IValidator<VM_User_SignIn> _singInUserValidator;
        private readonly IValidator<ResetPassword> _resetPasswordValidator;
        private readonly IEmailService _emailService;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<AppRole> roleManager, IValidator<VM_User_Create> userValidator, IValidator<VM_User_SignIn> singInUserValidator, IEmailService emailService, IValidator<ResetPassword> resetPasswordValidator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _userValidator = userValidator;
            _singInUserValidator = singInUserValidator;
            _emailService = emailService;
            _resetPasswordValidator = resetPasswordValidator;
       
        }
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(VM_User_Create model )
        {
            var appUser = new AppUser();
            appUser.Id = Guid.NewGuid().ToString();
            appUser.Email = model.Email;
            appUser.UserName = model.UserName;
            appUser.PhoneNumber = model.PhoneNumber;

            try
            {
                _userValidator.ValidateAndThrow(model);
                var response = await _userManager.CreateAsync(appUser, model.Password);
                if (response.Succeeded)
                {
                    var role = await _roleManager.FindByNameAsync("Member");
                    if (role == null)
                    {
                        var appRole = new AppRole()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Member"
                        };
                        await _roleManager.CreateAsync(appRole);
                    }

                    await _userManager.AddToRoleAsync(appUser, "Member");
                }
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
        public async Task<IActionResult>SignIn(VM_User_SignIn model)
        {
            try
            {
                _singInUserValidator.ValidateAndThrow(model);
                if (ModelState.IsValid)
                {
                    var appUser = await _userManager.FindByNameAsync(model.Username);

                    var response = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

                    if (response.Succeeded)
                    {
                        var role = await _userManager.GetRolesAsync(appUser);
                        //   var userId = await _userManager.FindByIdAsync(appUser.Id.ToString());
                        if (role.Contains("Member"))
                        {
                            return RedirectToAction("GetBlogTitle", "MemberBlog");
                        }
                        else if (role.Contains("Admin"))
                        {
                            return RedirectToAction("GetBlog", "Blog");
                        }
                        //   var user = await _userManager.FindByNameAsync(model.Username);

                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
           
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "User");
        }

        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                _resetPasswordValidator.ValidateAndThrow(resetPassword);
                var user = await _userManager.FindByEmailAsync(resetPassword.Email);
                if (user != null)
                {
                    var resetResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
                    if (resetResult.Succeeded)
                    {
                        return RedirectToAction("SignIn", "User");
                    }

                }
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
               // _resetPasswordValidator.ValidateAndThrow(resetPassword);
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

