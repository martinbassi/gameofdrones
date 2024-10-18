namespace GameOfDrones.Domain.Entities;

public class Game : BaseAuditableEntity
{
    public string Winner { get; set; } = default!;

    public string Opponent { get; init; } = default!;

    public DateTime Date { get; set; }
}
