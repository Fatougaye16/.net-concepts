using ToDoApp.Configurations;
using ToDoApp.Data;
using ToDoApp.Logging;

namespace ToDoApp.Endpoints.AddToDo;

public class AddToDoEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/todos", async (TodoContext db, Todo todo, ILogger<AddToDoEndpoint> logger) =>
        {
            logger.LogInformation(MyLogEvents.InsertItem,"To do endpoint called at: {ToShortTimeString}", DateTime.UtcNow.ToShortTimeString());
            await db.Todos.AddAsync(todo);
            await db.SaveChangesAsync();
            logger.LogInformation(MyLogEvents.InsertItem,"To do endpoint completed");
        });
    }
}