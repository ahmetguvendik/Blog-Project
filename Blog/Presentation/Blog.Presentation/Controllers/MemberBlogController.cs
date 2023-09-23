using Blog.Application.CQRS.Queries.Blog.GetAllBlog;
using Blog.Application.CQRS.Queries.Blog.GetByIdBlog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{

    [Authorize(Roles ="Admin,Member")]
    public class MemberBlogController : Controller
    {
        private readonly IMediator _mediator;
        public MemberBlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> GetBlogTitle(GetAllBlogQueryRequest model)
        {

            var blogs = await _mediator.Send(model);
            return View(blogs);
        }

        public async Task<IActionResult> DetailBlog(GetByIdBlogQueryRequest model)
        {
            var blog = await _mediator.Send(model);
            return View(blog);
        }
    }
}

