using GameOfDrones.Domain.Entities;
using GameOfDrones.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameOfDrones.Infrastructure.Data.Configurations;

public class GameRuleConfiguration : IEntityTypeConfiguration<GameRule>
{
    public void Configure(EntityTypeBuilder<GameRule> builder)
    {
        builder.ToTable("GameRules");

        builder.Property(x => x.ResultId).IsRequired();

        builder.HasOne(d => d.Movement)
          .WithMany()
          .HasForeignKey(d => d.MovementId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_GameRules_Movements");

        builder.HasOne(d => d.OppMovement)
          .WithMany()
          .HasForeignKey(d => d.OppMovementId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_GameRules_OppMovements");

        builder.HasOne(d => d.Result)
          .WithMany()
          .HasForeignKey(d => d.ResultId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_GameRules_Results");

        SeedData(builder);
    }
    private void SeedData(EntityTypeBuilder<GameRule> builder)
    {
        var data = new GameRule[]
        {
                new GameRule
                {
                    Id = 1,
                    MovementId = 1,
                    OppMovementId = 2,
                    ResultId = ResultId.Win
                },
                new GameRule
                {
                    Id = 2,
                    MovementId = 1,
                    OppMovementId = 3,
                    ResultId = ResultId.Lose
                },
                new GameRule
                {
                    Id = 3,
                    MovementId = 1,
                    OppMovementId = 1,
                    ResultId = ResultId.Draw
                },

                new GameRule
                {
                    Id = 4,
                    MovementId = 2,
                    OppMovementId = 2,
                    ResultId = ResultId.Draw
                },
                new GameRule
                {
                    Id = 5,
                    MovementId = 2,
                    OppMovementId = 3,
                    ResultId = ResultId.Win
                },
                new GameRule
                {
                    Id = 6,
                    MovementId = 2,
                    OppMovementId = 1,
                    ResultId = ResultId.Lose
                },

                new GameRule
                {
                    Id = 7,
                    MovementId = 3,
                    OppMovementId = 2,
                    ResultId = ResultId.Lose
                },
                new GameRule
                {
                    Id = 8,
                    MovementId = 3,
                    OppMovementId = 3,
                    ResultId = ResultId.Draw
                },
                new GameRule
                {
                    Id = 9,
                    MovementId = 3,
                    OppMovementId = 1,
                    ResultId = ResultId.Win
                },
        };

        builder.HasData(data);
    }
}
