using System.ComponentModel.DataAnnotations;

namespace MovieApp.Backend.Models
{
    public class OfflineMovie
    {
        [Key]
        public int Id { get; set; }
        public int MovideID { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
