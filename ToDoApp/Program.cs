using Microsoft.EntityFrameworkCore;
using ToDoApp;
using ToDoApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlite("Data Source=sqlite.db"));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/todos", async (TodoContext db, Todo todo) =>
{
    await db.Todos.AddAsync(todo);
    await db.SaveChangesAsync();
});

app.MapGet("/todos", async (TodoContext db) =>
{
    var todos = await db.Todos.ToListAsync();
    return todos;
});

app.MapPut("/todos/{id}", async (TodoContext db, int id, TodoDto todoDto) =>
{
    var todo = await db.Todos.FindAsync(id);
    
    if(todo == null)
        return Results.NotFound();
    todo.Title = todoDto.Title;
    todo.Description = todoDto.Description;
    todo.IsComplete = todoDto.IsComplete;
    todo.CreatedAt = todoDto.CreatedAt;
    
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/todos/{id}", async (TodoContext db, int id) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo == null)
    {
        return Results.NotFound();
    }

    db.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.Run();
