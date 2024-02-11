using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using MovieApp.Backend.Models;

namespace MovieApp.Backend.DataAccess
{
    public class MovieDbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        private IOptions<AppSettings> _settings;

        public MovieDbContextFactory(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        public MovieDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MovieDbContext>();
            var connectionString = configuration.GetConnectionString(_settings.Value.SQLConnection);
            builder.UseSqlServer(connectionString);

            return new MovieDbContext(_settings, builder.Options);
        }
    }
}
