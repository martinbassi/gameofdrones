using GameOfDrones.Application.Common.Interfaces;

namespace GameOfDrones.Application.Games.Queries.GetGames;

public record GetGamesQuery : IRequest<IEnumerable<GameDto>>
{
}

public class GetGamesQueryHandler : IRequestHandler<GetGamesQuery, IEnumerable<GameDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGamesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GameDto>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Games.AsNoTracking()
            .OrderByDescending(x => x.Date).Take(10)
            .ProjectTo<GameDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
