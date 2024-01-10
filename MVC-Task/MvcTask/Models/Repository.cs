using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTask.Models
{
    public static class Repository
    {
        static Repository()
        {
            Categories.Add(new Category()
            {
                Id = 1,
                Name = "A kategorisi"
            });
        }
        public static List<Category> Categories { get; set; } = new List<Category>();
        public static List<Product> Products { get; set; } = new List<Product>();
        public static void CreateCategory(Category category)
        {
            Categories.Add(category);
        }
        public static void CreateProduct(Product product)
        {
            Products.Add(product);
        }
    }
}