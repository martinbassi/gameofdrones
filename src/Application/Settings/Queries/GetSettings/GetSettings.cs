using GameOfDrones.Application.Common.Interfaces;
using GameOfDrones.Application.Games.Queries.GetGames;

namespace GameOfDrones.Application.Settings.Queries.GetSettings;

public record GetSettingsQuery : IRequest<SettingDto>
{
}

public class GetSettingsQueryHandler : IRequestHandler<GetSettingsQuery, SettingDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSettingsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SettingDto> Handle(GetSettingsQuery request, CancellationToken cancellationToken)
    {
        var movements = await _context.Movements.AsNoTracking().OrderBy(x => x.Name)
            .Select(x => x.Name).ToListAsync(cancellationToken: cancellationToken);

        var rules = await _context.GameRules.AsNoTracking()
            .ProjectTo<GameRuleDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);

        return new SettingDto() {
            Movements = movements,
            Rules = rules
        };
    }
}
