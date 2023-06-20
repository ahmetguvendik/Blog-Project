using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{

    [Authorize(Roles ="Admin,Member")]
    public class MemberBlogController : Controller
    {
        private readonly IBlogReadRepository _readRepository;
        public MemberBlogController(IBlogReadRepository readRepository)
        {
            _readRepository = readRepository;
        }
        public IActionResult GetBlogTitle()
        {

            var blogs = _readRepository.GetAll();
            return View(blogs);
        }

        public async Task<IActionResult> DetailBlog(string id)
        {
            var blog = await _readRepository.GetById(id);
            return View(blog);
        }
    }
}

