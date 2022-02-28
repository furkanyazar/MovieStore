using System;

namespace WebApi.Models.Movies
{
    public class CreateMovieModel
    {
        public string Name { get; set; }
        public DateTime YearOfConstruction { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public decimal Price { get; set; }
    }
}
