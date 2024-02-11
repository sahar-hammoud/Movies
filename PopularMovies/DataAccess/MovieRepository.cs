using MovieApp.Backend.DataAccess;
using MovieApp.Backend.Models;

namespace MoviesApp.Backend.DataAccessLayer
{
    public class MovieRepository: IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public MovieDetails GetMovieById(int movieId)
        {
            return _context.MovieDetails.FirstOrDefault(x => x.Id == movieId);
        }

        public Actor GetActorsByMovieId(int movieId)
        {
            return _context.Actors.FirstOrDefault(x => x.MovieId == movieId);
        }

        public Video GetVideosByMovieId(int movieId)
        {
            return _context.Videos.FirstOrDefault(x => x.MovieId == movieId);
        }

        public Review GetReviewsByMovieId(int movieId)
        {
            return _context.Reviews.FirstOrDefault(x => x.MovieId == movieId);
        }

        public Similar GetSimilarsByMovieId(int movieId)
        {
            return _context.Similars.FirstOrDefault(x => x.MovieId == movieId);
        }

    }
}

