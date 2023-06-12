﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Features.Commands.Blog.CreateBlog;
using Blog.Application.Features.Commands.Blog.RemoveBlog;
using Blog.Application.Features.Queries.Blog.GetAllBlog;
using Blog.Application.Features.Queries.Blog.GetByIdBlog;
using Blog.Application.Repositories;
using Blog.Application.ViewModels.Blog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogWriteRepository _writeRepository;
        private readonly IBlogReadRepository _readRepository;
        public BlogController(IBlogWriteRepository writeRepository, IBlogReadRepository readRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetBlog()
        {
           var blogs = _readRepository.GetAll();
           return View(blogs);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateBlog()
        {
            return View();
        }
          
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateBlog(VM_Blog_Create model)
        {
            var blog = new Domain.Entities.Blog();
            blog.Id = Guid.NewGuid().ToString();
            blog.Title = model.Title;
            blog.Description = model.Description;
            blog.CreatedTime = DateTime.UtcNow;
            await _writeRepository.AddBlogAsync(blog);
            await _writeRepository.SaveAsync();
            return View();
        }

        [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> UpdateBlog(VM_Blog_Update model)
        {
            var blog = await _readRepository.GetById(model.Id);
            blog.Title = model.Title;
            blog.Description = model.Description;
            blog.UpdatedTime = DateTime.UtcNow;
            await _writeRepository.SaveAsync();
            return RedirectToAction("GetBlog", "Blog");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveBlog(string id)
        {
            await _writeRepository.RemoveAsync(id);
            await _writeRepository.SaveAsync();
            return RedirectToAction("GetBlog", "Blog");

        }
    }
}

