using Microsoft.EntityFrameworkCore;
using ToDoApp.Configurations;
using ToDoApp.Data;

namespace ToDoApp.Endpoints.SeeToDos;

public class SeeToDosEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/todos", async (TodoContext db) =>
        {
            var todos = await db.Todos.ToListAsync();
            return todos;
        });    
    }
}