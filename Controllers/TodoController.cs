using cqrs_example.Services;
using cqrs_example.Services.Todos;
using Microsoft.AspNetCore.Mvc;

namespace cqrs_example.Controllers;

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
        return Ok(await _createTodo.Execute(todo));
    }

    [HttpPut()]
    public async Task<ActionResult<bool>> UpdateTodo([FromBody] UpdateTodoRequest todo)
    {
        return Ok(await _updateTodo.Execute(todo));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteTodo(int id)
    {
        var todo = new DeleteTodoRequest {
            Id = id
        };
        return Ok(await _deleteTodo.Execute(todo));
    }

    [HttpPost("search")]
    public async Task<ActionResult<List<Todo>>> SearchTodo([FromBody] SearchTodoRequest todo)
    {
        return Ok(await _searchTodo.Execute(todo));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Todo>> GetTodo(int id)
    {
        var todoResponse = await _getTodo.Execute(
            new GetTodoRequest
            {
                Id = id
            }
        );
        
        return (todoResponse.Todo == null) ? NotFound() : Ok(todoResponse.Todo);

    }


}
