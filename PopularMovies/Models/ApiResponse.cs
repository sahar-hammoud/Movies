namespace MovieApp.Backend.Models
{
    public class ApiResponse<T>
    {
        public int id { get; set; }
        public int page { get; set; }
        public List<T> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
        public List<T> cast { get; set; }   
    }
}
