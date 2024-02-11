using MovieApp.Frontend.Models;
using Newtonsoft.Json;
using System.Text;

namespace MovieApp.Frontend.Services
{
    public class MovieApiClient : IMovieApiClient
    {
        private readonly HttpClient _httpClient;

        public MovieApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> GetPopularMoviesAsync()
        {
            var response = await _httpClient.GetAsync("api/movies/GetPopularMoviesList");
            response.EnsureSuccessStatusCode();
            var movies = await response.Content.ReadAsAsync<List<Movie>>();
            return movies;
        }

        public async Task<MovieDetails> GetMovieDetailsAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/movies/GetMovieDetails/{id}");
            response.EnsureSuccessStatusCode();
            var movieDetails = await response.Content.ReadAsAsync<MovieDetails>();
            return movieDetails;
        }

        public async Task<List<Video>> GetMovieVideosAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/movies/GetMovieVideos/{id}");
            response.EnsureSuccessStatusCode();
            var movieVideos = await response.Content.ReadAsAsync<List<Video>>();
            return movieVideos;
        }

        public async Task<List<Actor>> GetMovieActorsAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/movies/GetMovieActors/{id}");
            response.EnsureSuccessStatusCode();
            var movieActors = await response.Content.ReadAsAsync<List<Actor>>();
            return movieActors;
        }

        public async Task<List<Review>> GetMovieReviewsAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/movies/GetMovieReviews/{id}");
            response.EnsureSuccessStatusCode();
            var movieReviews = await response.Content.ReadAsAsync<List<Review>>();
            return movieReviews;
        }

        public async Task<List<Similar>> GetMovieSimilarsAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/movies/GetMovieSimilars/{id}");
            response.EnsureSuccessStatusCode();
            var movieSimilar = await response.Content.ReadAsAsync<List<Similar>>();
            return movieSimilar;
        }

        public async Task<string> SaveOfflineList(string offlineList)
        {
            var jsonContent = JsonConvert.SerializeObject(offlineList);

            var request = new HttpRequestMessage(HttpMethod.Post, "api/movies/AddToOfflineList")
            {
                Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }

    }
}
