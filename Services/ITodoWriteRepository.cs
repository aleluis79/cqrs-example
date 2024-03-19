using cqrs_example.Services.Todos;

namespace cqrs_example.Services;

public interface ITodoRepositoryWrite
{
    Task<bool> CreateTodo(CreateTodoRequest todo);

    Task<bool> UpdateTodo(int id, UpdateTodoRequest todo);

    Task<bool> DeleteTodo(int id);

}
