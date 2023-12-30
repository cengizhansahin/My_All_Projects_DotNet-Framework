#region En Temel Sorgulamamız

#endregion

using Microsoft.EntityFrameworkCore;
//Console.WriteLine("Hello, World!");
CodeFirstECommerceContext c = new CodeFirstECommerceContext();
#region Veri Tabanına Data Ekleme ve Listeleme İşlmeleri
var p = 0;
for (int i = 1; i <= 1002; i++)
{
    p += 10;
    Product product = new()
    {
        ProductName = $"Ürün{i}",
        Price = p,
    };
    await c.Products.AddAsync(product);
}
await c.SaveChangesAsync();

// --> INumerable ile listeleme işlemi
//List<Product> products = c.Products.ToList();
//foreach (Product product in products)
//{
//    Console.WriteLine($"ID: {product.ID}\tName: {product.ProductName}\tFiyat: {product.Price}");
//}

// --> IQueryable ile listeleme işlemi
//var products = (from p in c.Products
//                select p).ToList();
//foreach (Product product in products)
//{
//    Console.WriteLine($"ID: {product.ID}\tName: {product.ProductName}\tFiyat: {product.Price}");
//}

//query syntax --> INumerable ve IQueryable farkı (IQueryable Ef Core üzerinden veritabanına yapılan sorgunun execute edilmemiş haline denen isim ve veri tipi)
//var urunler2 = (from x in c.Products
//                select x).ToList();
#endregion
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
//var urunler = c.Products.Where(p => p.Fiyat > 500 && p.ProductName.EndsWith("7")).OrderByDescending(x => x.Fiyat).ThenByDescending(x => x.ProductName).ToList();
//foreach (var item in urunler)
//{
//    Console.WriteLine($"ID: {item.ID}\tName: {item.ProductName}\tPrice: {item.Fiyat}");
//}
#endregion
#region Tekil Veri Getiren Sorgulamalar
//Single, SingleOrDefault, FirstOrDefault, Find, Last, LastOrDefault
//var urunx = c.Products.Single(x => x.ID > 60); //Birden çok element döndüreceği için hata olacaktır.
//var urunx = c.Products.Single(x => x.ID > 20000); //Hiç eleman döndürmediği için hata döndürecektir.
//var urunx = c.Products.Single(x => x.ID == 5);
//var urunx = c.Products.SingleOrDefault(x => x.ID > 60); //Yine hata alacağız
//var urunx = c.Products.Single(x => x.ID > 60000);//Null döner
//var urunx = c.Products.First(x => x.ID > 60);
//Console.WriteLine(urunx.ID);
//var urunx = c.Products.First(x => x.ID > 20000);// hata ( Sequence contains no elements )
//var urunx = c.Products.FirstOrDefault(x => x.ID > 60);
//var x = await c.Products.FirstOrDefaultAsync(p => p.ID == 55);
//Console.WriteLine(x.ProductName);
//var nesne = c.Products.Find(55);
//Console.WriteLine(nesne.ProductName);

#endregion
public class CodeFirstECommerceContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-S5SNUUO;Database=CodeFirstECommerce;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
public class Product
{
    public int ID { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
}