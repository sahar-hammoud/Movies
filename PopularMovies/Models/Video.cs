using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Backend.Models
{
    public class Video
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        
        // Foreign Key to Movie class
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
