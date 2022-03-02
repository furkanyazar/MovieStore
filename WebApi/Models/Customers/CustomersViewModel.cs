using System;
using System.Collections.Generic;

namespace WebApi.Models.Customers
{
    public class CustomersViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> MoviesOfCustomer { get; set; }
        public List<string> GenresOfCustomer { get; set; }
    }
}
