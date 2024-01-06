var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// request pipeline
//authentication
//
app.MapGet("/", () => "Hello World!");

app.Run();
