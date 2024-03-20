using cqrs_example.Application.UseCases.Todos.Commands;
using cqrs_example.Application.UseCases.Todos.Queries;
using cqrs_example.Domain.Models;
using cqrs_example.Domain.Ports.Out;
using cqrs_example.Infraestructure.Repositories;
using cqrs_example.Infraestructure.Services;

namespace cqrs_example.Infraestructure.Extensions;

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
    }

}
