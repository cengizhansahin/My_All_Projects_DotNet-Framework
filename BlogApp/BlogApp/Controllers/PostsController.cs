using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _repository;
        public PostsController(IPostRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var model = _repository.Posts.ToList();
            return View(model);
        }
    }
}