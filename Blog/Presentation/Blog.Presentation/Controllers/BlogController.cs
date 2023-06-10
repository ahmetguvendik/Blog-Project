using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Features.Commands.Blog.CreateBlog;
using Blog.Application.Features.Queries.Blog.GetAllBlog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    public class BlogController : Controller
    {
        private readonly IMediator _mediator;
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlog()
        {
            var response = await _mediator.Send(new GetAllBlogQueryRequest());
            return View(response);
        }

        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return View();
        }

        [HttpPut]
        public IActionResult UpdateBlog()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveBlog()
        {
            return View();
        }
    }
}

