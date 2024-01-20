using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_efCoreApp.DATA;
using MVC_efCoreApp.Models;

namespace MVC_efCoreApp.Controllers
{
    public class KursController : Controller
    {
        private readonly DataContext _context;
        public KursController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var kurslar = await _context.Kurslar
                        .Include(o => o.Ogretmen).ToListAsync();
            return View(kurslar);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KursViewModel model)
        {
            if(ModelState.IsValid)
            {
                var kurs = new Kurs();
                kurs.Baslik = model.Baslik;
                kurs.OgretmenId = model.OgretmenId;
                kurs.KursKayitlari = model.KursKayitlari;
            _context.Kurslar.Add(kurs);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kurs = await _context.Kurslar
                        .Include(k => k.KursKayitlari)
                        .ThenInclude(k => k.Ogrenci).FirstOrDefaultAsync(p => p.KursId == id);
            if (kurs == null)
            {
                return NotFound();
            }
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");
            return View(kurs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(KursViewModel obj, int id)
        {
            if (id != obj.KursId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(new Kurs()
                    {
                        KursId = obj.KursId,
                        Baslik = obj.Baslik,
                        OgretmenId = obj.OgretmenId
                    });
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Ogrenciler.Any(x => x.OgrenciId == obj.KursId))
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
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kurs = await _context.Kurslar.FirstOrDefaultAsync(p => p.KursId == id);
            if (kurs == null)
            {
                return NotFound();
            }
            return View(kurs);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Kurs kurs)
        {
            if (kurs == null)
            {
                return NotFound();
            }
            _context.Kurslar.Remove(kurs);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}