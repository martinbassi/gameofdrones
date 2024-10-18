using GameOfDrones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameOfDrones.Infrastructure.Data.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games");

        builder.Property(t => t.Winner)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Winner)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Date)
            .IsRequired();
    }
}
