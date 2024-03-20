using cqrs_example.Domain.Ports.Out;
using cqrs_example.Infraestructure.Services;

namespace cqrs_example.Application.UseCases.Todos.Commands;

public class UpdateTodoRequest {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class UpdateTodo : IRequestHandler<UpdateTodoRequest>
{

    private readonly ITodoRepositoryWrite _todoRepositoryWrite;

    public UpdateTodo(ITodoRepositoryWrite todoRepositoryWrite)
    {
        _todoRepositoryWrite = todoRepositoryWrite;
    }

    public Task<bool> Do(UpdateTodoRequest request)
    {
        _todoRepositoryWrite.UpdateTodo(request.Id, request);

        // Publish event in the future

        return Task.FromResult(true);

    }
}
