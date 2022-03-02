using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorMovieOperations.Commands.DeleteDirectorMovie
{
    public class DeleteDirectorMovieCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int DirectorMovieId { get; set; }

        public DeleteDirectorMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var directorMovie = _context.DirectorMovies.SingleOrDefault(x => x.Id == DirectorMovieId);

            if (directorMovie is null) throw new InvalidOperationException("Bulunamadı");

            _context.DirectorMovies.Remove(directorMovie);
            _context.SaveChanges();
        }
    }
}
