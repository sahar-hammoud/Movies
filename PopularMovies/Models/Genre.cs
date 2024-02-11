using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Backend.Models
{
    public class Genre
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        // Relationship with MovieDetails
        public virtual ICollection<MovieDetails> Movies { get; set; }
    }
}
