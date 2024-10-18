using GameOfDrones.Domain.Enums;

namespace GameOfDrones.Domain.Entities;

public class Result
{
    public ResultId Id { get; set; }

    public string Name { get; set; } = default!;
}
