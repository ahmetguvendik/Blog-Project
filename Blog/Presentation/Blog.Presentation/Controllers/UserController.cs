using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Features.Commands.User.CreateUser;
using Blog.Application.Features.Commands.User.SignInUser;
using Blog.Application.Services;
using Blog.Application.ViewModels.User;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ITokenHandler _handler;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler handler,RoleManager<AppRole> roleManager)
        {
            _handler = handler;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
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
            var response =  await _userManager.CreateAsync(appUser, model.Password);
            if (response.Succeeded)
            {
                var role = await _roleManager.FindByNameAsync("Member");
                if(role == null)
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

            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>SignIn(VM_User_SignIn model)
        {
            if (ModelState.IsValid)
            {             
                var response = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false,false);
                if (response.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Username);
                     var token = _handler.CreateAccessToken(user);
                    return RedirectToAction("GetBlog", "Blog");
                }
            }
           
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "User");
        }
    }
}

