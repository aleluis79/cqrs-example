namespace cqrs_example.Services.Todos;

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

    public Task<List<Todo>> Execute(SearchTodoRequest request)
    {
        return Task.FromResult(
            _todoRepositoryRead.GetTodos().Result
                .Where(x => x.IsCompleted == request.IsCompleted)
                .ToList());
    }
}
