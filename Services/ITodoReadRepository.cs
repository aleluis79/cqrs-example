namespace cqrs_example.Services;

public interface ITodoRepositoryRead
{

    Task<Todo?> GetTodo(int id);

    Task<IEnumerable<Todo>> GetTodos();

}
