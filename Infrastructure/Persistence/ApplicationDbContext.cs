using cqrs_example.Domain.Models;
using cqrs_example.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace cqrs_example.Infraestructure.Persistence;

public class ApplicationDbContext : DbContext
{

    public DbSet<TodoEntity> Todos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}