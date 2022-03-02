using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models.Customers;

namespace WebApi.Application.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int CustomerId { get; set; }
        public UpdateCustomerModel Model { get; set; }

        public UpdateCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);

            if (customer is null) throw new InvalidOperationException("Müşteri bulunamadı");

            customer.FirstName = string.IsNullOrEmpty(Model.FirstName.Trim()) ? customer.FirstName : Model.FirstName;
            customer.LastName = string.IsNullOrEmpty(Model.LastName.Trim()) ? customer.LastName : Model.LastName;

            _context.SaveChanges();
        }
    }
}
