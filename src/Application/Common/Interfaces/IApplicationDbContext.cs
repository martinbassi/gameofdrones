using GameOfDrones.Domain.Entities;

namespace GameOfDrones.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Game> Games { get; }

    DbSet<GameRule> GameRules { get; }

    DbSet<Movement> Movements { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
