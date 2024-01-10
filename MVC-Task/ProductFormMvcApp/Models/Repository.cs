using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductFormMvcApp.Models
{
    public static class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _category = new();
        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        public static List<Category> Categories
        {
            get
            {
                return _category;
            }
        }
    }
}