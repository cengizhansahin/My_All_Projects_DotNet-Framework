// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
#region Veri Ekleme
ETicaretDbContext ETicaretDbContext = new ETicaretDbContext();
Urun urun = new()
{
    UrunAdi = "Cengizhan ram bellekleri",
    MyProperty = 456

};
Urun urun1 = new()
{
    UrunAdi = "samet ram bellekleri",
    MyProperty = 456

};
Urun urun2 = new()
{
    UrunAdi = "mahmut ram bellekleri",
    MyProperty = 456

};
Urun urun3 = new()
{
    UrunAdi = "enver ram bellekleri",
    MyProperty = 456

};
//ETicaretDbContext.uruns.Add(urun);
//ETicaretDbContext.uruns.AddRange(urun1, urun2, urun3);
//ETicaretDbContext.SaveChanges();
#endregion
#region Veri Silme
var silinecekUrun = ETicaretDbContext.uruns.FirstOrDefault(u => u.Id == 3);
//ETicaretDbContext.uruns.Remove(silinecekUrun);
//ETicaretDbContext.SaveChanges();
#endregion
#region Veri Güncelleme
var guncellenecekUrun = ETicaretDbContext.uruns.FirstOrDefault(u => u.Id == 2);
guncellenecekUrun.UrunAdi = "Güncelleme işlemi yapıldı!";
ETicaretDbContext.SaveChanges();
#endregion
public class ETicaretDbContext : DbContext
{
    public DbSet<Urun> uruns { get; set; }
    public DbSet<User> users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-S5SNUUO;Database=CodeFirstETicaretDb;Trusted_Connection=True; TrustServerCertificate=True");
    }
}

public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public int MyProperty { get; set; }
}
public class User
{
    public int UserID { get; set; }
    public string UserName { get; set; }
}