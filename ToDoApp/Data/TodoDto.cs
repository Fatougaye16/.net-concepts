namespace ToDoApp.Data;

public record TodoDto
(
    string Title,
    bool IsComplete,
    DateTime CreatedAt,
    string Description
);