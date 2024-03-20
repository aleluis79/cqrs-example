using cqrs_example.Domain.Models;
using cqrs_example.Domain.Ports.Out;
using cqrs_example.Infraestructure.Services;

namespace cqrs_example.Application.UseCases.Todos.Queries;

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

    public Task<GetTodoResponse> Do(GetTodoRequest request, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(
            new GetTodoResponse
            {
                Todo = _todoRepositoryRead.GetTodo(request.Id, cancellationToken).Result
            }
        );
        
    }
}
