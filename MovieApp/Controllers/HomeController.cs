using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Frontend.Models;
using MovieApp.Frontend.Services;

namespace MovieApp.Frontend.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMovieApiClient _movieApiClient;

        public HomeController(IMovieApiClient movieApiClient)
        {
            _movieApiClient = movieApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieApiClient.GetPopularMoviesAsync();
            return View(movies);
        }

        public async Task<IActionResult> MovieDetails(int id)
        {
            MovieViewModel model = new MovieViewModel();

            model.MovieDetails = await _movieApiClient.GetMovieDetailsAsync(id);
            model.Videos = await _movieApiClient.GetMovieVideosAsync(id);
            model.Actors = await _movieApiClient.GetMovieActorsAsync(id);
            model.Reviews = await _movieApiClient.GetMovieReviewsAsync(id);
            model.Similar = await _movieApiClient.GetMovieSimilarsAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToOfflineList(string offlineList)
        {
            string message = await _movieApiClient.SaveOfflineList(offlineList);
            return Ok(message);
        }
    }
}
