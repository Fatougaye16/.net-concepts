using ToDoApp.Configurations;
using ToDoApp.Data;

namespace ToDoApp.Endpoints.RemoveToDo;

public class RemoveToDoEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
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
        });    }
}