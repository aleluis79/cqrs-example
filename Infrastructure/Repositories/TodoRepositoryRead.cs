using AutoMapper;
using cqrs_example.Domain.Models;
using cqrs_example.Domain.Ports.Out;
using cqrs_example.Infraestructure.Entities;
using cqrs_example.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace cqrs_example.Infraestructure.Repositories;

public class TodoRepositoryRead : ITodoRepositoryRead
{

    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public TodoRepositoryRead(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }    

    public async Task<Todo?> GetTodo(int id, CancellationToken cancellationToken = default)
    {
        var todo = await _context.Todos.FindAsync(id, cancellationToken);

        if (todo == null)
        {
            return null;
        }

        return _mapper.Map<TodoEntity, Todo>(todo);

    }

    public async Task<IEnumerable<Todo>> GetTodos(bool IsCompleted, CancellationToken cancellationToken = default)
    {
        var todos = await _context.Todos.Where(x => x.IsCompleted == IsCompleted).ToListAsync(cancellationToken);
        
        return _mapper.Map<IEnumerable<TodoEntity>, IEnumerable<Todo>>(todos);
    }
}
