using GameOfDrones.Application.Common.Exceptions;
using GameOfDrones.Application.Games.Commands.CreateGame;
using GameOfDrones.Domain.Entities;

namespace GameOfDrones.Application.FunctionalTests.TodoItems.Commands;

using static Testing;

public class CreateGameTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateGameCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateGame()
    {
        var command = new CreateGameCommand
        {
            Winner = "Winner",
            Opponent = "Opponent"
        };

        var itemId = await SendAsync(command);

        var item = await FindAsync<Game>(itemId);

        item.Should().NotBeNull();
        item!.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
