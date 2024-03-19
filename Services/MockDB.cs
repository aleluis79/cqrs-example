
namespace cqrs_example.Services;

public class MockDB : IMockBD
{

    private List<Todo> Todos = new List<Todo>();

    public Task<bool> Create(Todo todo)
    {
        Todos.Add(todo);
        return Task.FromResult(true);
    }

    public Task<bool> Delete(int id)
    {
        var todo = Todos.FirstOrDefault(x => x.Id == id);
        if (todo == null)
        {
            return Task.FromResult(false);
        } else {
            Todos.Remove(todo);
            return Task.FromResult(true);
        }
    }

    public Task<List<Todo>> FindAll()
    {
        return Task.FromResult(Todos);
    }

    public Task<Todo?> FindById(int id)
    {
        return Task.FromResult(Todos.FirstOrDefault(x => x.Id == id));
    }

    public Task<bool> Update(int id, Todo todo)
    {
        var todoToUpdate = Todos.FirstOrDefault(x => x.Id == id);
        if (todoToUpdate == null)
        {
            return Task.FromResult(false);
        } else {
            Todos.Remove(todoToUpdate);
            Todos.Add(todo);
            return Task.FromResult(true);
        }
    }
}
