using GameOfDrones.Domain.Entities;
using GameOfDrones.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameOfDrones.Infrastructure.Data.Configurations;

public class ResultConfiguration : IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("Results");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(10);

        SeedData(builder);
    }
    private void SeedData(EntityTypeBuilder<Result> builder)
    {
        var data = new Result[]
        {
                new Result
                {
                    Id = ResultId.Win,
                    Name = "Win"
                },
                new Result
                {
                    Id = ResultId.Lose,
                    Name = "Lose"
                },
                new Result
                {
                    Id = ResultId.Draw,
                    Name = "Draw"
                }
        };

        builder.HasData(data);
    }
}
