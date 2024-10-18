using GameOfDrones.Application.Games.Commands.CreateGame;
using GameOfDrones.Application.Games.Queries.GetGames;

namespace GameOfDrones.Web.Endpoints;

public class Games : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetGames)
            .MapPost(CreateGame);
    }

    public Task<IEnumerable<GameDto>> GetGames(ISender sender, [AsParameters] GetGamesQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateGame(ISender sender, CreateGameCommand command)
    {
        return sender.Send(command);
    }
}
