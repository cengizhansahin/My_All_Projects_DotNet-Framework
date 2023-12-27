using DbFirstProject.DAL;
DbContextInitializer.Build();
using (var _context = new AppDbContext(DbContextInitializer.OptionsBuilder.Options))
{
    var products = _context.Products.ToList();
    products.ForEach(p =>
    {
        Console.WriteLine($"ID: {p.Id} - Name: {p.Name} - Price: {p.Price} TL");
    });
}