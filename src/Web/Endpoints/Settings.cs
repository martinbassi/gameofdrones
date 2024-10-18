using GameOfDrones.Application.Settings.Queries.GetSettings;

namespace GameOfDrones.Web.Endpoints;

public class Settings : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetSettings);
    }

    public Task<SettingDto> GetSettings(ISender sender, [AsParameters] GetSettingsQuery query)
    {
        return sender.Send(query);
    }
}
