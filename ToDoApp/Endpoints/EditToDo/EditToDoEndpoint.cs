using ToDoApp.Configurations;
using ToDoApp.Data;

namespace ToDoApp.Endpoints.EditToDo;

public class EditToDoEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
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
        });    }
}