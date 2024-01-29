using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.ViewComponents
{
    public class NewPosts : ViewComponent
    {
        private readonly IRepository<Post> _postRepository;
        public NewPosts(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _postRepository.List.OrderByDescending(x => x.PublishedOn).Take(5).ToListAsync());
        }
    }
}