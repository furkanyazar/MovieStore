using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models.Directors;

namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int DirectorId { get; set; }
        public UpdateDirectorModel Model { get; set; }

        public UpdateDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Id == DirectorId);

            if (director is null) throw new InvalidOperationException("Yönetmen bulunamadı");

            if (_context.Directors.Any(x => x.FirstName.ToLower() == director.FirstName.ToLower() && x.LastName.ToLower() == director.LastName.ToLower() && director.Id != DirectorId)) throw new InvalidOperationException("Yönetmen zaten mevcut");

            director.FirstName = string.IsNullOrEmpty(Model.FirstName.Trim()) ? director.FirstName : Model.FirstName;
            director.LastName = string.IsNullOrEmpty(Model.LastName.Trim()) ? director.LastName : Model.LastName;

            _context.SaveChanges();
        }
    }
}
