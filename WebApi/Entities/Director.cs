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
        public List<DirectorMovie> MoviesOfDirector { get; set; } = new List<DirectorMovie>();
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
