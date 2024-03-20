
using cqrs_example.Application.UseCases.Todos.Commands;
using cqrs_example.Domain.Ports.Out;
using cqrs_example.Infraestructure.Entities;
using cqrs_example.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace cqrs_example.Infraestructure.Repositories;

public class TodoRepositoryWrite : ITodoRepositoryWrite
{
    private readonly ApplicationDbContext _context;

    public TodoRepositoryWrite(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<bool> CreateTodo(CreateTodoRequest todo)
    {
        var id = _context.Todos.Count() + 1;

        _context.Todos.Add(new TodoEntity {
            Id = id,
            Name = todo.Name,
            Description = todo.Description,
            IsCompleted = false
        });

        _context.SaveChanges();

        return Task.FromResult(true);
    }

    public Task<bool> DeleteTodo(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo == null)
        {
            return Task.FromResult(false);
        }
        _context.Todos.Remove(todo);

        _context.SaveChanges();

        return Task.FromResult(true);
    }

    public Task<bool> UpdateTodo(int id, UpdateTodoRequest todo)
    {
        var todoAux = _context.Todos.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        if (todoAux == null)
        {
            return Task.FromResult(false);
        }

        _context.Todos.Update(new TodoEntity
        {
            Id = id,
            Name = todo.Name,
            Description = todo.Description,
            IsCompleted = false
        });

        _context.SaveChanges();

        return Task.FromResult(true);
    }
}
