using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models.Movies;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int MovieId { get; set; }
        public UpdateMovieModel Model { get; set; }

        public UpdateMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);

            if (movie is null) throw new InvalidOperationException("Film bulunamadı");

            if (_context.Movies.Any(x => x.Name.ToLower() == movie.Name.ToLower() && movie.Id != MovieId)) throw new InvalidOperationException("Film zaten mevcut");

            movie.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? movie.Name : Model.Name;
            movie.DirectorId = Model.DirectorId != default ? Model.DirectorId : movie.DirectorId;
            movie.GenreId = Model.GenreId != default ? Model.GenreId : movie.GenreId;
            movie.Price = Model.Price != default ? Model.Price : movie.Price;

            _context.SaveChanges();
        }
    }
}
