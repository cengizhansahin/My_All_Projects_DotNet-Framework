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

namespace MVC_efCoreApp.Controllers
{
    public class KursKayitController : Controller
    {

        private readonly DataContext _context;

        public KursKayitController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var KursKayitlari = await _context
                                .KursKayitlari
                                .Include(x => x.Ogrenci)
                                .Include(x => x.Kurs)
                                .ToListAsync();
            return View(KursKayitlari);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciId", "AdSoyad");
            ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "Baslik");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(KursKayit model)
        {
            model.KayitTarihi = DateTime.Now;
            _context.KursKayitlari.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}