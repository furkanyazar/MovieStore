using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models.Genres;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }

        public UpdateGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            
            if (genre is null) throw new InvalidOperationException("Film türü bulunamadı");
            
            if (_context.Genres.Any(x => x.Name.ToLower() == genre.Name.ToLower() && genre.Id != GenreId))
                throw new InvalidOperationException("Film türü zaten mevcut");
            
            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;

            _context.SaveChanges();
        }
    }
}
