using ToDoApp.Configurations;
using ToDoApp.Data;

namespace ToDoApp.Endpoints.AddToDo;

public class AddToDoEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/todos", async (TodoContext db, Todo todo) =>
        {
            await db.Todos.AddAsync(todo);
            await db.SaveChangesAsync();
        });
        
    }
}