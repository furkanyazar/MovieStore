using System.Collections.Generic;

namespace WebApi.Models.Actors
{
    public class ActorsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> MoviesOfActor { get; set; }
    }
}
