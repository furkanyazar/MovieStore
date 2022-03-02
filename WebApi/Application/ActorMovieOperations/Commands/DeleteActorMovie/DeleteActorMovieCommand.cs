using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.ActorMovieOperations.Commands.DeleteActorMovie
{
    public class DeleteActorMovieCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int ActorMovieId { get; set; }

        public DeleteActorMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actorMovie = _context.ActorMovies.SingleOrDefault(x => x.Id == ActorMovieId);

            if (actorMovie is null) throw new InvalidOperationException("Bulunamadı");

            _context.ActorMovies.Remove(actorMovie);
            _context.SaveChanges();
        }
    }
}
