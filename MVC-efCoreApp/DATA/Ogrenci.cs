using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_efCoreApp.DATA
{
    public class Ogrenci
    {
        //id KEY
        [Key]
        public int OgrenciId { get; set; }
        public string? OgrenciAd { get; set; }
        public string? OgrenciSoyadi { get; set; }
        public string AdSoyad
        {
            get
            {
                return this.OgrenciAd + " " + this.OgrenciSoyadi;
            }
        }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        public int MyProperty { get; set; }
    }
}