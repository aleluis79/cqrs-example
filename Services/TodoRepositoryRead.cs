namespace cqrs_example.Services;

public class TodoRepositoryRead : ITodoRepositoryRead
{

    private readonly IMockBD _mockBD;

    public TodoRepositoryRead(IMockBD mockBD)
    {
        _mockBD = mockBD;
    }    

    public Task<Todo?> GetTodo(int id)
    {
        return Task.FromResult(_mockBD.FindById(id).Result);
    }

    public Task<IEnumerable<Todo>> GetTodos()
    {
        return Task.FromResult(_mockBD.FindAll().Result.AsEnumerable());
    }
}
