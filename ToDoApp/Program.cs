using Microsoft.EntityFrameworkCore;
using ToDoApp.Configurations;
using ToDoApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlite("Data Source=sqlite.db"));
builder.Logging.AddConsole();
builder.Services.AddEndpoints(typeof(AddEndpointsService).Assembly);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapEndpoints();

app.Run();
