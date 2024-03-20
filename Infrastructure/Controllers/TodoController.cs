using cqrs_example.Application.UseCases.Todos.Commands;
using cqrs_example.Application.UseCases.Todos.Queries;
using cqrs_example.Domain.Models;
using cqrs_example.Infraestructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace cqrs_example.Infraestructure.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> _logger;

    private readonly IRequestHandler<CreateTodoRequest> _createTodo;

    private readonly IRequestHandler<UpdateTodoRequest> _updateTodo;

    private readonly IRequestHandler<DeleteTodoRequest> _deleteTodo;

    private readonly IRequestHandler<SearchTodoRequest, List<Todo>> _searchTodo;

    private readonly IRequestHandler<GetTodoRequest, GetTodoResponse> _getTodo;

    public TodoController(
            ILogger<TodoController> logger, 
            IRequestHandler<CreateTodoRequest> createTodo,
            IRequestHandler<UpdateTodoRequest> updateTodo,
            IRequestHandler<DeleteTodoRequest> deleteTodo,
            IRequestHandler<SearchTodoRequest, List<Todo>> searchTodo,
            IRequestHandler<GetTodoRequest, GetTodoResponse> getTodo)
    {
        _logger = logger;
        _createTodo = createTodo;
        _updateTodo = updateTodo;
        _deleteTodo = deleteTodo;
        _searchTodo = searchTodo;
        _getTodo = getTodo;
    }

    [HttpGet("ping")]
    public ActionResult<string> Ping()
    {
        return Ok("pong");
    }

    [HttpPost()]
    public async Task<ActionResult<bool>> CreateTodo([FromBody] CreateTodoRequest todo)
    {
        return Ok(await _createTodo.Do(todo));
    }

    [HttpPut()]
    public async Task<ActionResult<bool>> UpdateTodo([FromBody] UpdateTodoRequest todo)
    {
        return Ok(await _updateTodo.Do(todo));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteTodo(int id)
    {
        var todo = new DeleteTodoRequest {
            Id = id
        };
        return Ok(await _deleteTodo.Do(todo));
    }

    [HttpPost("search")]
    public async Task<ActionResult<List<Todo>>> SearchTodo([FromBody] SearchTodoRequest todo)
    {
        return Ok(await _searchTodo.Do(todo, cancellationToken: default));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Todo>> GetTodo(int id)
    {
        var todoResponse = await _getTodo.Do(
            new GetTodoRequest
            {
                Id = id
            },
            cancellationToken: default
        );
        
        return (todoResponse.Todo == null) ? NotFound() : Ok(todoResponse.Todo);

    }


}
