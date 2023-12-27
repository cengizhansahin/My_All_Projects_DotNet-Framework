// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
public class ETicaretDbContext : DbContext
{
    public DbSet<Urun> uruns { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-S5SNUUO;Database=CodeFirstETicaretDb;Trusted_Connection=True;");
    }
}

public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public int MyProperty { get; set; }
}