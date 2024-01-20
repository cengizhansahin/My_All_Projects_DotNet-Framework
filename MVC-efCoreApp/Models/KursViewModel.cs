using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_efCoreApp.DATA;

namespace MVC_efCoreApp.Models
{
    public class KursViewModel
    {
        public int KursId { get; set; }
        public string? Baslik { get; set; }
        public int? OgretmenId { get; set; }
        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}