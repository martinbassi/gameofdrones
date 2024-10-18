using GameOfDrones.Domain.Entities;
using GameOfDrones.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameOfDrones.Infrastructure.Data.Configurations;

public class MovementConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(100)
            .IsRequired();

        SeedData(builder);
    }
    private void SeedData(EntityTypeBuilder<Movement> builder)
    {
        var data = new Movement[]
        {
                new Movement
                {
                    Id = 1,
                    Name = "Rock"
                },
                new Movement
                {
                    Id = 2,
                    Name = "Scissors"
                },
                new Movement
                {
                    Id = 3,
                    Name = "Paper"
                }
        };

        builder.HasData(data);
    }
}
