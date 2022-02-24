using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime YearOfConstruction { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public List<ActorMovie> ActorsOfMovie { get; set; } = new List<ActorMovie>();
        public decimal Price { get; set; }
    }
}
