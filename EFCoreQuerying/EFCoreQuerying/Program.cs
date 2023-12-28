#region En Temel Sorgulamamız

#endregion

using Microsoft.EntityFrameworkCore;
//Console.WriteLine("Hello, World!");

CodeFirstECommerceContext c = new CodeFirstECommerceContext();
//for (int i = 1; i <= 1002; i++)
//{
//    Product product = new()
//    {
//        ProductName = $"Urun{i}",
//        Fiyat = i * 10
//    };
//    await c.Products.AddAsync(product);
//}
//await c.SaveChangesAsync();

//List<Product> products = c.Products.ToList();
//foreach (var item in products)
//{
//    Console.WriteLine($"ID: {item.ID}\tName: {item.ProductName}\tFiyat: {item.Fiyat}");
//}

//query syntax --> INumerable ve IQueryable farkı (IQueryable Ef Core üzerinden veritabanına yapılan sorgunun execute edilmemiş haline denen isim ve veri tipi)
//var urunler2 = (from x in c.Products
//                select x).ToList();

#region Çoğul Veri Getiren Sorgulamalar
//ToList
//var urunler = c.Products.Where(p => p.Fiyat > 500 && p.Fiyat < 600).ToList();
//var urunler = from x in c.Products
//              where (x.Fiyat > 500 && x.Fiyat < 600)
//              select x;
//foreach (var item in urunler)
//{
//    Console.WriteLine($"ID: {item.ID}\tName: {item.ProductName}\tPrice: {item.Fiyat}");
//}

//var urunler = c.Products.Where(p => p.Fiyat > 500 && p.ProductName.EndsWith("7")).OrderBy(x=>x.Fiyat).ToList();
//foreach (var item in urunler)
//{
//    Console.WriteLine($"ID: {item.ID}\tName: {item.ProductName}\tPrice: {item.Fiyat}");
//}
//var urunler = c.Products.Where(p => p.Fiyat > 500 && p.ProductName.EndsWith("7")).OrderByDescending(x => x.Fiyat).ToList();
//foreach (var item in urunler)
//{
//    Console.WriteLine($"ID: {item.ID}\tName: {item.ProductName}\tPrice: {item.Fiyat}");
//}
var urunler = c.Products.Where(p => p.Fiyat > 500 && p.ProductName.EndsWith("7")).OrderByDescending(x => x.Fiyat).ThenByDescending(x => x.ProductName).ToList();
foreach (var item in urunler)
{
    Console.WriteLine($"ID: {item.ID}\tName: {item.ProductName}\tPrice: {item.Fiyat}");
}
#endregion
#region Tekil Veri Getiren Sorgulamalar

#endregion
public class CodeFirstECommerceContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-S5SNUUO;Database=CodeFirstECommerce;Trusted_Connection=True; TrustServerCertificate=True");
    }
}




public class Product
{
    public int ID { get; set; }
    public string ProductName { get; set; }
    public double Fiyat { get; set; }
}