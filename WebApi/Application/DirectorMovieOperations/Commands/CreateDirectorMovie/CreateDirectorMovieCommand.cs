using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Models.DirectorMovies;

namespace WebApi.Application.DirectorMovieOperations.Commands.CreateDirectorMovie
{
    public class CreateDirectorMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateDirectorMovieModel Model { get; set; }

        public CreateDirectorMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var directorMovie = _context.DirectorMovies.SingleOrDefault(x => x.DirectorId == Model.DirectorId && x.MovieId == Model.MovieId);

            if (directorMovie is not null) throw new InvalidOperationException("Zaten mevcut");

            directorMovie = _mapper.Map<DirectorMovie>(Model);

            _context.DirectorMovies.Add(directorMovie);
            _context.SaveChanges();
        }
    }
}
