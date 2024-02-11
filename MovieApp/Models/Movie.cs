namespace MovieApp.Frontend.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public List<int> GenreIds { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }


    public class MovieDetails:Movie
    {
        public MovieCollection BelongsToCollection { get; set; }
        public int Budget { get; set; }
        public string Homepage { get; set; }
        public string ImdbId { get; set; }
        public List<Genre> Genres { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MovieCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
    }

    public class ProductionCompany
    {
        public int Id { get; set; }
        public string LogoPath { get; set; }
        public string Name { get; set; }
        public string OriginCountry { get; set; }
    }


    public class SpokenLanguage
    {
        public string EnglishName { get; set; }
        public string Iso6391 { get; set; }
        public string Name { get; set; }
    }

    public class Video
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }
        public string Type { get; set; }
        
    }

    public class Review
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public AuthorDetails AuthorDetails  { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

    }

    public class AuthorDetails
    {
        public string Name { get; set; }
        public string Rating { get; set; }
    }

    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
        public string ProfilePath { get; set; }
    }

    public class Similar
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public List<int> GenreIds { get; set; }
        public int Id { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}
