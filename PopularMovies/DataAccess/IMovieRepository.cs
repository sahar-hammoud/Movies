using MovieApp.Backend.Models;

namespace MovieApp.Backend.DataAccess
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        MovieDetails GetMovieById(int movieId);
        Actor GetActorsByMovieId(int movieId);
        Video GetVideosByMovieId(int movieId);
        Review GetReviewsByMovieId(int movieId);
        Similar GetSimilarsByMovieId(int movieId);
    }
}
