using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> MovieIds { get; set; }
        public List<Movie> Movies { get; set; }
        public List<int> GenreIds { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
