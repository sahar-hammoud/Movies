using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieApp.Backend.Models;

namespace MovieApp.Backend.DataAccess
{
    public class MovieDbContext : DbContext
    {
        private IOptions<AppSettings> _settings;

        public MovieDbContext()
        {
        }

        public MovieDbContext(IOptions<AppSettings> settings, DbContextOptions<MovieDbContext> options)
            : base(options)
        {
            _settings = settings;
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDetails> MovieDetails { get; set; }
        public DbSet<MovieCollection> MovieCollections { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<MovieProductionCompany> MoviesProductionCompanies { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Similar> Similars { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<OfflineMovie> OfflineMovies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.Value.SQLConnection);
        }

    }
}
