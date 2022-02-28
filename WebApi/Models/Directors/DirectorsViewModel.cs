using System.Collections.Generic;

namespace WebApi.Models.Directors
{
    public class DirectorsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> MoviesOfDirector { get; set; }
    }
}
