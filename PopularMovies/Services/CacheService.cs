using Microsoft.Extensions.Caching.Memory;
using MovieApp.Backend.Models;
using MovieApp.Backend.Service;

namespace MovieApi.Service
{
    public class CacheService
    {
        private readonly MovieService _movieService;
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache, MovieService movieService)
        {
            _cache = cache;
            _movieService = movieService;
        }

        public async Task<List<Movie>> GetPopularMovies()
        {
            if (!_cache.TryGetValue("PopularMovies", out List<Movie> popularMovies))
            {
                popularMovies = await _movieService.FetchPopularMoviesFromApi();

                _cache.Set("PopularMovies", popularMovies, TimeSpan.FromHours(1));
            }

            return popularMovies;
        }

        public async Task<MovieDetails> GetMovieDetailsAsync(int movieId)
        {
            if (!_cache.TryGetValue($"MovieDetails_{movieId}", out MovieDetails movieDetails))
            {
                movieDetails = await _movieService.FetchMovieDetailsFromApi(movieId);

                _cache.Set($"MovieDetails_{movieId}", movieDetails, TimeSpan.FromDays(1));
            }

            return movieDetails;
        }

        public async Task<List<Video>> GetMovieVideosAsync(int movieId)
        {         
            if (!_cache.TryGetValue($"MovieVideos_{movieId}", out List<Video> movieVideos))
            {

                movieVideos = await _movieService.FetchMovieVideosFromApi(movieId);

                _cache.Set($"MovieVideos_{movieId}", movieVideos, TimeSpan.FromDays(1));
            }

            return movieVideos;
        }

        public async Task<List<Actor>> GetMovieActorsAsync(int movieId)
        {
            if (!_cache.TryGetValue($"MovieActors_{movieId}", out List<Actor> movieActors))
            {

                movieActors = await _movieService.FetchMovieActorsFromApi(movieId);

                _cache.Set($"MovieActors_{movieId}", movieActors, TimeSpan.FromDays(1));
            }

            return movieActors;
        }

        public async Task<List<Review>> GetMovieReviewsAsync(int movieId)
        {
            if (!_cache.TryGetValue($"MovieReviews_{movieId}", out List<Review> movieReviews))
            {

                movieReviews = await _movieService.FetchMovieReviewsFromApi(movieId);

                _cache.Set($"MovieReviews_{movieId}", movieReviews, TimeSpan.FromDays(1));
            }

            return movieReviews;
        }

        public async Task<List<Similar>> GetMovieSimilarsAsync(int movieId)
        {
            if (!_cache.TryGetValue($"MovieSimilars_{movieId}", out List<Similar> movieSimilars))
            {

                movieSimilars = await _movieService.FetchMovieSimilarsFromApi(movieId);

                _cache.Set($"MovieSimilars_{movieId}", movieSimilars, TimeSpan.FromDays(1));
            }

            return movieSimilars;
        }
   
    }
}
