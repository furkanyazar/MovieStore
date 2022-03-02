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
        public List<CustomerMovie> MoviesOfCustomer { get; set; } = new List<CustomerMovie>();
        public List<CustomerGenre> GenresOfCustomer { get; set; } = new List<CustomerGenre>();
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
