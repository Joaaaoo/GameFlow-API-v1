using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GameFlow.Infrastructure
{
    public class GameFlowDbContextFactory : IDesignTimeDbContextFactory<GameFlowDbContext>
    {
        public GameFlowDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GameFlowDbContext>();

            // Configure a connection string
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../GameFlow.API")) // Ajuste o caminho base
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new GameFlowDbContext(optionsBuilder.Options);
        }
    }
}
