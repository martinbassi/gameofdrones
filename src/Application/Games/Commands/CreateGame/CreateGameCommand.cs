using GameOfDrones.Application.Common.Interfaces;
using GameOfDrones.Domain.Entities;

namespace GameOfDrones.Application.Games.Commands.CreateGame;

public record CreateGameCommand : IRequest<int>
{
    public string Winner { get; init; } = default!;

    public string Opponent { get; init; } = default!;
}

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateGameCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var entity = new Game
        {
            Date = DateTime.Now,
            Winner = request.Winner,
            Opponent = request.Opponent
        };

        _context.Games.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
