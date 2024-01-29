using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<Tag> _tagRepository;
        private readonly IRepository<Comment> _commentRepository;

        public PostsController(IRepository<Post> postRepository, IRepository<Tag> tagRepository, IRepository<Comment> commentRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _commentRepository = commentRepository;
        }
        public IActionResult Index(string tag)
        {
            var claims = User.Claims;
            var posts = _postRepository.List;
            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
                return View(posts.ToList());
            }
            else
            {
                // new PostViewModel
                // {
                //     Posts = await _postRepository.Posts.ToListAsync(),
                //     // Tags = _tagRepository.Tags.ToList()
                // };
                return View(posts.ToList());
            }
        }
        public async Task<IActionResult> Details(string? url)
        {
            return View(await _postRepository
            .List
            .Include(x => x.Tags)
            .Include(x => x.Comments)
            .ThenInclude(x => x.User)
            .FirstOrDefaultAsync(x => x.Url == url));
        }
        [HttpPost]
        public JsonResult AddComment(int PostId, string Text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);
            var entity = new Comment
            {
                Text = Text,
                PublishedOn = DateTime.Now,
                PostId = PostId,
                UserId = int.Parse(userId ?? "")
            };
            _commentRepository.Create(entity);
            return Json(new
            {
                username,
                Text,
                entity.PublishedOn,
                avatar
            });
        }
    }
}