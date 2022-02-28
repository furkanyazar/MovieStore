using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models.Actors;

namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int ActorId { get; set; }
        public UpdateActorModel Model { get; set; }

        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == ActorId);

            if (actor is null) throw new InvalidOperationException("Oyuncu bulunamadı");

            if (_context.Actors.Any(x => x.FirstName.ToLower() == actor.FirstName.ToLower() && x.LastName.ToLower() == actor.LastName.ToLower() && actor.Id != ActorId)) throw new InvalidOperationException("Oyuncu zaten mevcut");

            actor.FirstName = string.IsNullOrEmpty(Model.FirstName.Trim()) ? actor.FirstName : Model.FirstName;
            actor.LastName = string.IsNullOrEmpty(Model.LastName.Trim()) ? actor.LastName : Model.LastName;

            _context.SaveChanges();
        }
    }
}
