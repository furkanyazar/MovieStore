using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int CustomerId { get; set; }

        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);

            if (customer is null) throw new InvalidOperationException("Müşteri bulunamadı");

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
