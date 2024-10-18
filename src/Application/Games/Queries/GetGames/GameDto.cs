using GameOfDrones.Domain.Entities;

namespace GameOfDrones.Application.Games.Queries.GetGames;

public class GameDto
{
    public int Id { get; init; }

    public string Winner { get; init; } = default!;

    public string Opponent { get; init; } = default!;

    public DateTime Date { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Game, GameDto>();
        }
    }
}
