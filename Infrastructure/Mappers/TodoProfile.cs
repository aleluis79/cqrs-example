using AutoMapper;
using cqrs_example.Domain.Models;
using cqrs_example.Infraestructure.Entities;

namespace cqrs_example.Infraestructure.Mappers;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<TodoEntity, Todo>();
        CreateMap<Todo, TodoEntity>();
    }
}