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
            var actor = _context.ActorMovies.SingleOrDefault(x => x.Id == ActorMovieId);

            if (actor is null) throw new InvalidOperationException("Bulunamadı");

            _context.ActorMovies.Remove(actor);
            _context.SaveChanges();
        }
    }
}
