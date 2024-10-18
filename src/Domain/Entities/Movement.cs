namespace GameOfDrones.Domain.Entities;

public class Movement : BaseAuditableEntity
{
    public string Name { get; set; } = default!;
}
