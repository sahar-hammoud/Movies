using Newtonsoft.Json;

namespace MovieApp.Backend.Models
{
    public class MovieCollection
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        // Relationship with MovieDetails
        public virtual ICollection<MovieDetails> MovieDetails { get; set; }
    }
}
