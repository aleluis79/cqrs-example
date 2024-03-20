using cqrs_example.Domain.Models;

namespace cqrs_example.Domain.Ports.Out;

public interface ITodoRepositoryRead
{

    Task<Todo?> GetTodo(int id, CancellationToken cancellationToken);

    Task<IEnumerable<Todo>> GetTodos(bool IsCompleted, CancellationToken cancellationToken);

}
