using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductFormMvcApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}