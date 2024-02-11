using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Service;
using MovieApp.Backend.DataAccess;
using MovieApp.Backend.Models;
using MovieApp.Frontend.Models;
using Newtonsoft.Json;

namespace MovieApp.Backend.Controllers
{
    public class MoviesController : Controller
    {
        private readonly CacheService _movieService;
        private readonly MovieDbContext _dbContext;
        public MoviesController(CacheService movieService, MovieDbContext dbContext)
        {
            _movieService = movieService;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> GetPopularMoviesList()
        {
            var popularMovies = await _movieService.GetPopularMovies();
            if(popularMovies != null)
            {
                return Ok(popularMovies);
            }
            else
            {
                return StatusCode(500, "An error has occured");
            }         
        }

        public async Task<IActionResult> GetMovieDetails(int id)
        {
            var movieDetails = await _movieService.GetMovieDetailsAsync(id);
            if (movieDetails != null)
            {
                return Ok(movieDetails);
            }
            else
            {
                return StatusCode(500, "An error has occured");
            }
            
        }

        public async Task<IActionResult> GetMovieVideos(int id)
        {
            var movieVideos = await _movieService.GetMovieVideosAsync(id);
            if (movieVideos != null)
            {
                return Ok(movieVideos);
            }
            else
            {
                return StatusCode(500, "An error has occured");
            }

        }

        public async Task<IActionResult> GetMovieActors(int id)
        {
            var movieActors = await _movieService.GetMovieActorsAsync(id);
            if (movieActors != null)
            {
                return Ok(movieActors);
            }
            else
            {
                return StatusCode(500, "An error has occured");
            }

        }

        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var movieReviews = await _movieService.GetMovieReviewsAsync(id);
            if (movieReviews != null)
            {
                return Ok(movieReviews);
            }
            else
            {
                return StatusCode(500, "An error has occured");
            }
        }

        public async Task<IActionResult> GetMovieSimilars(int id)
        {
            var movieSimilars = await _movieService.GetMovieSimilarsAsync(id);
            if (movieSimilars != null)
            {
                return Ok(movieSimilars);
            }
            else
            {
                return StatusCode(500, "An error has occured");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToOfflineList([FromBody]  string offlineMovie)
        {
            MovieViewModel offlineList = JsonConvert.DeserializeObject<MovieViewModel>(offlineMovie);
            var offlineMovieInfo = new OfflineMovie 
            {
                MovideID = offlineList.MovieDetails.Id,
                Title = offlineList.MovieDetails.Title, 
                Overview = offlineList.MovieDetails.Overview, 
                ReleaseDate = Convert.ToDateTime(offlineList.MovieDetails.ReleaseDate)
            };
            _dbContext.OfflineMovies.Add(offlineMovieInfo);
            //await _dbContext.SaveChangesAsync();
            if (string.IsNullOrEmpty(offlineMovie))
            {
                return BadRequest("An error has occured");
            }

            return Ok("Offline list saved successfully");
        }
    }
}
