using System.ComponentModel.DataAnnotations;

namespace MovieApp.Backend.Models
{
    public class MovieProductionCompany
    {
        [Key]
        public int Id { get; set; }
        public int MovieDetailsId { get; set; }
        public MovieDetails MovieDetails { get; set; }
        public int ProductionCompanyId { get; set; }
        public ProductionCompany ProductionCompany { get; set; }
    }
}
