using cqrs_example.Domain.Ports.Out;
using cqrs_example.Infraestructure.Services;

namespace cqrs_example.Application.UseCases.Todos.Commands;

public class DeleteTodoRequest {
    public int Id { get; set; }
}

public class DeleteTodo : IRequestHandler<DeleteTodoRequest>
{

    private readonly ITodoRepositoryWrite _todoRepositoryWrite;

    public DeleteTodo(ITodoRepositoryWrite todoRepositoryWrite)
    {
        _todoRepositoryWrite = todoRepositoryWrite;
    }

    public Task<bool> Do(DeleteTodoRequest request)
    {
        _todoRepositoryWrite.DeleteTodo(request.Id);

        // Publish event in the future

        return Task.FromResult(true);

    }
}
