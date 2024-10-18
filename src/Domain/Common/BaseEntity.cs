using System.ComponentModel.DataAnnotations.Schema;

namespace GameOfDrones.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
}
