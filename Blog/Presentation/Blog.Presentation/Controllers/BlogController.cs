using Blog.Application.CQRS.Commands.Blog.CreateBlog;
using Blog.Application.CQRS.Commands.Blog.RemoveBlog;
using Blog.Application.CQRS.Commands.Blog.UpdateBlog;
using Blog.Application.CQRS.Queries.Blog.GetAllBlog;
using Blog.Application.CQRS.Queries.Blog.GetByIdBlog;
using Blog.Application.CQRS.Queries.Blog.UpdateGetByIdBlog;
using Blog.Application.Repositories;
using Blog.Application.ViewModels.Blog;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BlogController : Controller
    {
        private readonly IMediator _mediator;
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlog(GetAllBlogQueryRequest model)
        {
            var response =  await _mediator.Send(model);
           return View(response);
        }

        public IActionResult CreateBlog()
        {
            return View();
        }
          
        [HttpPost]
         public async Task<IActionResult> CreateBlog(CreateBlogCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return View(response);
        }

       
        public async Task<IActionResult> UpdateBlog(UpdateGetbyIdBlogQueryRequest model)
        {
            if(model.Id == null)
            {
                return RedirectToAction("GetBlog", "Blog");
            }

            var response =  await _mediator.Send(model);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommandRequest model)
        {
            await _mediator.Send(model);
            return RedirectToAction("GetBlog", "Blog");
        }

       
        public async Task<IActionResult> RemoveBlog(RemoveBlogCommandRequest model)
        {
            await _mediator.Send(model);
            return RedirectToAction("GetBlog", "Blog");

        }
    }
}

