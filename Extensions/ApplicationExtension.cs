using cqrs_example.Services;
using cqrs_example.Services.Todos;

namespace cqrs_example;

public static class ApplicationExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITodoRepositoryRead, TodoRepositoryRead>();
        services.AddScoped<ITodoRepositoryWrite, TodoRepositoryWrite>();
        services.AddScoped<IRequestHandler<CreateTodoRequest>, CreateTodo>();
        services.AddScoped<IRequestHandler<UpdateTodoRequest>, UpdateTodo>();
        services.AddScoped<IRequestHandler<DeleteTodoRequest>, DeleteTodo>();
        services.AddScoped<IRequestHandler<SearchTodoRequest, List<Todo>>, SearchTodo>();
        services.AddScoped<IRequestHandler<GetTodoRequest, GetTodoResponse>, GetTodo>();

        services.AddSingleton<IMockBD, MockDB>();
    }

}
