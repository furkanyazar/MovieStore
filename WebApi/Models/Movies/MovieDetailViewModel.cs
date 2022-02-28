using System;
using System.Collections.Generic;

namespace WebApi.Models.Movies
{
    public class MovieDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime YearOfConstruction { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public List<string> ActorsOfMovie { get; set; }
        public decimal Price { get; set; }
    }
}
