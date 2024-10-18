using GameOfDrones.Domain.Enums;

namespace GameOfDrones.Domain.Entities;

public class GameRule : BaseAuditableEntity
{
    public int MovementId { get; set; } = default!;

    public int OppMovementId { get; init; } = default!;

    public ResultId ResultId { get; set; }

    public virtual Movement Movement { get; set; } = default!;

    public virtual Movement OppMovement { get; set; } = default!;

    public virtual Result Result { get; set; } = default!;
}
