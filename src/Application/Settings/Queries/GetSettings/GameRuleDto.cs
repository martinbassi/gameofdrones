using GameOfDrones.Domain.Entities;
using GameOfDrones.Domain.Enums;

namespace GameOfDrones.Application.Games.Queries.GetGames;

public class GameRuleDto
{
    public string Movement { get; set; } = default!;

    public string OppMovement { get; set; } = default!;

    public ResultId ResultId { get; set; }

    public string Result { get; set; } = default!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<GameRule, GameRuleDto>()
                .ForMember(d => d.Movement, o => o.MapFrom(s => s.Movement.Name))
                .ForMember(d => d.OppMovement, o => o.MapFrom(s => s.OppMovement.Name))
                .ForMember(d => d.Result, o => o.MapFrom(s => s.Result.Name));
        }
    }
}
