using Blog.Application.CQRS.Commands.Blog.CreateBlog;
using Blog.Application.CQRS.Commands.Blog.RemoveBlog;
using Blog.Application.CQRS.Commands.Blog.UpdateBlog;
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
        private readonly IBlogReadRepository _readRepository;
        private readonly IMediator _mediator;
        public BlogController(IBlogReadRepository readRepository,IMediator mediator)
        {
            _readRepository = readRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetBlog()
        {
           var blogs = _readRepository.GetAll();
           return View(blogs);
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

       
        public async Task<IActionResult> UpdateBlog(string id)
        {
            if(id == null)
            {
                return RedirectToAction("GetBlog", "Blog");
            }

            var blog = await _readRepository.GetById(id);
            VM_Blog_Update blogMapper = new VM_Blog_Update();
            blogMapper.Title = blog.Title;
            blogMapper.Description = blog.Description;
            return View(blogMapper);
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

