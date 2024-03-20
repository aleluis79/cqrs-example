using cqrs_example.Domain.Models;
using cqrs_example.Domain.Ports.Out;
using cqrs_example.Infraestructure.Services;

namespace cqrs_example.Application.UseCases.Todos.Queries;

public class SearchTodoRequest {
    public bool IsCompleted { get; set; } = false;
}

public class SearchTodo : IRequestHandler<SearchTodoRequest, List<Todo>>
{
    private readonly ITodoRepositoryRead _todoRepositoryRead;

    public SearchTodo(ITodoRepositoryRead todoRepositoryRead)
    {
        _todoRepositoryRead = todoRepositoryRead;
    }

    public async Task<List<Todo>> Do(SearchTodoRequest request, CancellationToken cancellationToken = default)
    {
        var todos = await _todoRepositoryRead.GetTodos(request.IsCompleted, cancellationToken);

        return todos.ToList();
    }
}
