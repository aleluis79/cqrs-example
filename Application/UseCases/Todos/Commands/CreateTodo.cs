using cqrs_example.Domain.Ports.Out;
using cqrs_example.Infraestructure.Services;

namespace cqrs_example.Application.UseCases.Todos.Commands;

public class CreateTodoRequest {
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class CreateTodo : IRequestHandler<CreateTodoRequest>
{

    private readonly ITodoRepositoryWrite _todoRepositoryWrite;

    public CreateTodo(ITodoRepositoryWrite todoRepositoryWrite)
    {
        _todoRepositoryWrite = todoRepositoryWrite;
    }

    public Task<bool> Do(CreateTodoRequest todo)
    {

        _todoRepositoryWrite.CreateTodo(todo);

        // Publish event in the future

        return Task.FromResult(true);
    }
}
