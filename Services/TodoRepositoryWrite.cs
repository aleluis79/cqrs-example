
using cqrs_example.Services.Todos;

namespace cqrs_example.Services;

public class TodoRepositoryWrite : ITodoRepositoryWrite
{
    private readonly IMockBD _mockBD;

    public TodoRepositoryWrite(IMockBD mockBD)
    {
        _mockBD = mockBD;
    }

    public Task<bool> CreateTodo(CreateTodoRequest todo)
    {
        var id = _mockBD.FindAll().Result.Count + 1;

        _mockBD.Create(new Todo {
            Id = id,
            Name = todo.Name,
            Description = todo.Description,
            IsCompleted = false
        });

        return Task.FromResult(true);
    }

    public Task<bool> DeleteTodo(int id)
    {
        _mockBD.Delete(id);

        return Task.FromResult(true);
    }

    public Task<bool> UpdateTodo(int id, UpdateTodoRequest todo)
    {
        _mockBD.Update(id, new Todo
        {
            Id = id,
            Name = todo.Name,
            Description = todo.Description,
            IsCompleted = false
        });
        return Task.FromResult(true);
    }
}
