using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerGenreOperations.Commands.DeleteCustomerGenre
{
    public class DeleteCustomerGenreCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int CustomerGenreId { get; set; }

        public DeleteCustomerGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customerGenre = _context.CustomerGenres.SingleOrDefault(x => x.Id == CustomerGenreId);

            if (customerGenre is null) throw new InvalidOperationException("Bulunamadı");

            _context.CustomerGenres.Remove(customerGenre);
            _context.SaveChanges();
        }
    }
}
