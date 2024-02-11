using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Backend.Models
{
    public class Review
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("author_details")]
        public AuthorDetails AuthorDetails { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        //Foreign Key to Movie class
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}

public class AuthorDetails
{
    [Key]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("rating")]
    public string Rating { get; set; }
}