using Kitaplik.Data;
using Kitaplik.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //List<Category> objCategoryLis = _context.Categories.ToList();
            IEnumerable<Category> categories = _context.Categories;
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                TempData["success"] = "Category created successfully";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var category = _context.Categories.FirstOrDefault(x => x.ID == id);
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                TempData["success"] = "Category updated successfully";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //Aşağıdaki [HttpGet] Delete action nunu oluşturup view eklemeden silme işlemini gerçekleştirebiliyorum.
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            TempData["success"] = "Category deleted successfully";
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    //var category = _context.Categories.FirstOrDefault(x => x.ID == id);
        //    var category = _context.Categories.Find(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int id)
        //{
        //    var category = _context.Categories.Find(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Categories.Remove(category);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
