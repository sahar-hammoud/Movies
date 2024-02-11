using Newtonsoft.Json;

namespace MovieApp.Backend.Models
{
    public class MovieDetails : Movie
    {

        [JsonProperty("budget")]
        public int Budget { get; set; }      
        public virtual ICollection<Genre> Genres { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("revenue")]
        public int Revenue { get; set; }

        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        //Relationship with MovieCollection
        public int? BelongsToCollectionId { get; set; }
        public virtual MovieCollection BelongsToCollection { get; set; }

        //Relationships with ProductionCompany
        public virtual ICollection<ProductionCompany> ProductionCompanies { get; set; }

        // Navigation property for Movie
        public int? MovieId { get; set; }
        public virtual Movie Movie { get; set; }

    }
 
}
