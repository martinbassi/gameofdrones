namespace GameOfDrones.Application.Games.Commands.CreateGame;

public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameCommandValidator()
    {
        RuleFor(v => v.Winner)
            .MaximumLength(100)
            .NotEmpty();

        RuleFor(v => v.Opponent)
            .MaximumLength(100)
            .NotEmpty();
    }
}
