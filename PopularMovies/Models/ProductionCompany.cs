using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Backend.Models
{
    public class ProductionCompany
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("logo_path")]
        public string LogoPath { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin_country")]
        public string OriginCountry { get; set; }

        // Relationship with MovieDetails
        public virtual ICollection<MovieDetails> MovieDetails { get; set; }
    }
}
