var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
// request pipeline
//authentication
//
//url/controller/action/id?
// app.MapDefaultControllerRoute();
// app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
);
app.Run();
