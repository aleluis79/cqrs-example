namespace cqrs_example.Services;

public interface IMockBD
{
    Task<bool> Create(Todo todo);
    Task<bool> Delete(int id);
    Task<bool> Update(int id, Todo todo);
    Task<List<Todo>> FindAll();
    Task<Todo?> FindById(int id);

}
