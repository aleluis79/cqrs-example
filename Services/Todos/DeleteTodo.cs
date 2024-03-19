namespace cqrs_example.Services.Todos;

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

    public Task<bool> Execute(DeleteTodoRequest request)
    {
        _todoRepositoryWrite.DeleteTodo(request.Id);

        // Publish event in the future

        return Task.FromResult(true);

    }
}
