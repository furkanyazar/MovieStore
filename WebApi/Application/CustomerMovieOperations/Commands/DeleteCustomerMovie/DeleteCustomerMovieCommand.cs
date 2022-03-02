using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerMovieOperations.Commands.DeleteCustomerMovie
{
    public class DeleteCustomerMovieCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int CustomerMovieId { get; set; }

        public DeleteCustomerMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customerMovie = _context.CustomerMovies.SingleOrDefault(x => x.Id == CustomerMovieId);

            if (customerMovie is null) throw new InvalidOperationException("Bulunamadı");

            _context.CustomerMovies.Remove(customerMovie);
            _context.SaveChanges();
        }
    }
}
