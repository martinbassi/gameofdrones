using GameOfDrones.Application.Games.Queries.GetGames;
using GameOfDrones.Domain.Entities;

namespace GameOfDrones.Application.Settings.Queries.GetSettings;

public class SettingDto
{
    public IEnumerable<string> Movements { get; set; } = [];

    public IEnumerable<GameRuleDto> Rules { get; set; } = default!;
}
