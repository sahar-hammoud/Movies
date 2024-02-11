using Newtonsoft.Json;

namespace MovieApp.Backend.Models
{
    public class Actor
    {

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("character")]
        public string Character { get; set; }
        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        // Foreign Key to Movie class
        public int MovieId { get; set; } 
        public virtual Movie Movie { get; set; }

    }
}
