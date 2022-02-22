using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public List<int> MovieIds { get; set; }
        [NotMapped]
        public List<Movie> Movies { get; set; }
    }
}
