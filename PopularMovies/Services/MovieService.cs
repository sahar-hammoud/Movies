using Microsoft.Extensions.Options;
using MovieApp.Backend.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace MovieApp.Backend.Service
{
    public class MovieService
    {
        private IOptions<AppSettings> _settings;
        public MovieService(IOptions<AppSettings> settings)
        {        
            _settings = settings;
        }
        public static string URIAppend(string uriString, params string[] paths)
        {
            Uri uri = new Uri(uriString);

            return new Uri(paths.Aggregate(uri.AbsoluteUri, (current, path) => string.Format("{0}/{1}", current.TrimEnd('/'), path.TrimStart('/')))).ToString();
        }

        public async Task<IRestResponse> Post(string methodName)
        {
            string token = _settings.Value.MoviesToken;
            string fullURL = URIAppend(_settings.Value.MoviesAPIBaseURL, methodName);
            var client = new RestClient(fullURL);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + token);  
            IRestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            return response;
        }
        public async Task<List<Movie>> FetchPopularMoviesFromApi()
        {
            List<Movie> result = new List<Movie>();
            string popularMovieUrl = string.Format("popular?language=en-US&page=1");
            IRestResponse response = await this.Post(popularMovieUrl);

            if (!string.IsNullOrEmpty(response.Content) && response.StatusCode == HttpStatusCode.OK)
            {
                var moviesResponse = JsonConvert.DeserializeObject<ApiResponse<Movie>>(response.Content);
                result = moviesResponse.results.OrderByDescending(x=>x.ReleaseDate).ToList();
            }
            else
            {
                Console.WriteLine("response.StatusCode=" + response.StatusCode);
            }

            return result;
        }

        public async Task<MovieDetails> FetchMovieDetailsFromApi(int movieID)
        {
            MovieDetails result = new MovieDetails();
            string movieDetailsUrl = string.Format("{0}?language=en-US", movieID);
            IRestResponse response = await this.Post(movieDetailsUrl);

            if (!string.IsNullOrEmpty(response.Content) && response.StatusCode == HttpStatusCode.OK)
            {
                MovieDetails movieDetailsResponse = JsonConvert.DeserializeObject<MovieDetails>(response.Content);
                result = movieDetailsResponse;
            }
            else
            {
                Console.WriteLine("response.StatusCode=" + response.StatusCode);
            }

            return result;
        }

        public async Task<List<Video>> FetchMovieVideosFromApi(int movieID)
        {
            List<Video> result = new List<Video>();
            string videoUrl = string.Format("{0}/videos?language=en-US", movieID);
            IRestResponse response = await this.Post(videoUrl);

            if (!string.IsNullOrEmpty(response.Content) && response.StatusCode == HttpStatusCode.OK)
            {
                ApiResponse<Video> videoResponse = JsonConvert.DeserializeObject<ApiResponse<Video>>(response.Content);
                result = videoResponse.results.Where(x => x.Type == "Trailer").ToList();
            }
            else
            {
                Console.WriteLine("response.StatusCode=" + response.StatusCode);
            }

            return result;
        }

        public async Task<List<Actor>> FetchMovieActorsFromApi(int movieID)
        {
            List<Actor> result = new List<Actor>();
            string actorUrl = string.Format("{0}/credits?language=en-US&page=1", movieID);
            IRestResponse response = await this.Post(actorUrl);

            if (!string.IsNullOrEmpty(response.Content) && response.StatusCode == HttpStatusCode.OK)
            {
                ApiResponse<Actor> actorResponse = JsonConvert.DeserializeObject<ApiResponse<Actor>>(response.Content);
                result = actorResponse.cast.Where(x => !string.IsNullOrEmpty(x.ProfilePath)).ToList();
            }
            else
            {
                Console.WriteLine("response.StatusCode=" + response.StatusCode);
            }

            return result;
        }

        public async Task<List<Review>> FetchMovieReviewsFromApi(int movieID)
        {
            List<Review> result = new List<Review>();
            string reviewUrl = string.Format("{0}/reviews?language=en-US&page=1", movieID);
            IRestResponse response = await this.Post(reviewUrl);

            if (!string.IsNullOrEmpty(response.Content) && response.StatusCode == HttpStatusCode.OK)
            {

                ApiResponse<Review> reviewResponse = JsonConvert.DeserializeObject<ApiResponse<Review>>(response.Content);
                result = reviewResponse.results;
            }
            else
            {
                Console.WriteLine("response.StatusCode=" + response.StatusCode);
            }

            return result;
        }
        public async Task<List<Similar>> FetchMovieSimilarsFromApi(int movieID)
        {

            List<Similar> result = new List<Similar>();
            string similarUrl = string.Format("{0}/similar?language=en-US&page=1", movieID);
            IRestResponse response = await this.Post(similarUrl);

            if (!string.IsNullOrEmpty(response.Content) && response.StatusCode == HttpStatusCode.OK)
            {

                ApiResponse<Similar> similarResponse = JsonConvert.DeserializeObject<ApiResponse<Similar>>(response.Content);
                result = similarResponse.results.Where(x => !string.IsNullOrEmpty(x.ReleaseDate) && !string.IsNullOrEmpty(x.PosterPath))
                                                .OrderByDescending(x=>x.ReleaseDate).ToList();
            }
            else
            {
                Console.WriteLine("response.StatusCode=" + response.StatusCode);
            }

            return result;
        }

    }
}
