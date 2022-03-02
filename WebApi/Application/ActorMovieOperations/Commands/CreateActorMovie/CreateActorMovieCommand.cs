using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Models.ActorMovies;

namespace WebApi.Application.ActorMovieOperations.Commands.CreateActorMovie
{
    public class CreateActorMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorMovieModel Model { get; set; }

        public CreateActorMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actorMovie = _context.ActorMovies.SingleOrDefault(x => x.ActorId == Model.ActorId && x.MovieId == Model.MovieId);

            if (actorMovie is not null) throw new InvalidOperationException("Zaten mevcut");

            actorMovie = _mapper.Map<ActorMovie>(Model);

            _context.ActorMovies.Add(actorMovie);
            _context.SaveChanges();
        }
    }
}
