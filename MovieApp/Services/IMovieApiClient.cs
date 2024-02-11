using MovieApp.Frontend.Models;

namespace MovieApp.Frontend.Services
{
    public interface IMovieApiClient
    {
        Task<List<Movie>> GetPopularMoviesAsync();
        Task<MovieDetails> GetMovieDetailsAsync(int id);
        Task<List<Video>> GetMovieVideosAsync(int id);
        Task<List<Actor>> GetMovieActorsAsync(int id);
        Task<List<Review>> GetMovieReviewsAsync(int id);
        Task<List<Similar>> GetMovieSimilarsAsync(int id);
        Task<string> SaveOfflineList(string offlineLst);
    }
}
