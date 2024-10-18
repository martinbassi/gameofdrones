using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GameOfDrones.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        string? connectionString = null;

        if (args.Length > 0)
        {
            connectionString = args[0];
        }

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        if (connectionString == null)
        {
            optionsBuilder.UseSqlServer();
        }
        else
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
