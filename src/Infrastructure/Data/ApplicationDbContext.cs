using System.Reflection;
using GameOfDrones.Application.Common.Interfaces;
using GameOfDrones.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameOfDrones.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Game> Games => Set<Game>();

    public DbSet<GameRule> GameRules => Set<GameRule>();

    public DbSet<Movement> Movements => Set<Movement>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
