using cqrs_example.Services;

namespace cqrs_example;

public class GetTodoRequest
{
    public int Id { get; set; }
}

public class GetTodoResponse {
    public Todo? Todo { get; set; }
}

public class GetTodo : IRequestHandler<GetTodoRequest, GetTodoResponse>
{

    private readonly ITodoRepositoryRead _todoRepositoryRead;

    public GetTodo(ITodoRepositoryRead todoRepositoryRead)
    {
        _todoRepositoryRead = todoRepositoryRead;
    }

    public Task<GetTodoResponse> Execute(GetTodoRequest request)
    {
        return Task.FromResult(
            new GetTodoResponse
            {
                Todo = _todoRepositoryRead.GetTodo(request.Id).Result
            }
        );
        
    }
}
