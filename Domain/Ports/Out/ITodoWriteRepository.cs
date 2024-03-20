using cqrs_example.Application.UseCases.Todos.Commands;

namespace cqrs_example.Domain.Ports.Out;

public interface ITodoRepositoryWrite
{
    Task<bool> CreateTodo(CreateTodoRequest todo);

    Task<bool> UpdateTodo(int id, UpdateTodoRequest todo);

    Task<bool> DeleteTodo(int id);

}
