using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ICommentRepository _commentRepository;

        public PostsController(IPostRepository postRepository, ITagRepository tagRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _commentRepository = commentRepository;
        }
        public IActionResult Index(string tag)
        {
            var posts = _postRepository.Posts;
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
            .Posts
            .Include(x => x.Tags)
            .Include(x => x.Comments)
            .ThenInclude(x => x.User)
            .FirstOrDefaultAsync(x => x.Url == url));
        }
        [HttpPost]
        public JsonResult AddComment(int PostId, string UserName, string Text)
        {
            var entity = new Comment
            {
                Text = Text,
                PublishedOn = DateTime.Now,
                PostId = PostId,
                User = new User
                {
                    UserName = UserName,
                    Image = "avatar.jpg"
                }
            };
            _commentRepository.CreateComment(entity);
            return Json(new
            {
                UserName,
                Text,
                entity.PublishedOn,
                entity.User.Image
            });
        }
    }
}