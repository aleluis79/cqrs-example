namespace cqrs_example.Services.Todos;

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

    public Task<bool> Execute(UpdateTodoRequest request)
    {
        _todoRepositoryWrite.UpdateTodo(request.Id, request);

        // Publish event in the future

        return Task.FromResult(true);

    }
}
