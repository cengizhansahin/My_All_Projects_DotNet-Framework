using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_efCoreApp.DATA;

namespace MVC_efCoreApp.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly DataContext _context;

        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.ToListAsync();
            return View(ogrenciler);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var updateOgrenci = await _context.Ogrenciler.FirstOrDefaultAsync(p => p.OgrenciId == id);
            if (updateOgrenci == null)
            {
                return NotFound();
            }
            return View(updateOgrenci);
        }
        [HttpPost]
        public async Task<IActionResult> Deletex([FromForm] int id)
        {
            var deleteOgrneci = await _context.Ogrenciler.FirstOrDefaultAsync(p => p.OgrenciId == id);
            if (deleteOgrneci == null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(deleteOgrneci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var updateOgrenci = await _context.Ogrenciler.FirstOrDefaultAsync(p => p.OgrenciId == id);
            if (updateOgrenci == null)
            {
                return NotFound();
            }
            return View(updateOgrenci);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ogrenci obj, int id)
        {
            if (id != obj.OgrenciId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Ogrenciler.Update(obj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Ogrenciler.Any(x => x.OgrenciId == obj.OgrenciId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}