using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int GenreId { get; set; }

        public DeleteGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            
            if (genre is null) throw new InvalidOperationException("Film türü bulunamadı");

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
