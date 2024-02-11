namespace MovieApp.Frontend.Models
{
    public class MovieViewModel
    {
        public List<Movie> Movies { get; set; }
        public MovieDetails MovieDetails { get; set; }
        public List<Video> Videos { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Similar> Similar { get; set; }
        
    }
}
