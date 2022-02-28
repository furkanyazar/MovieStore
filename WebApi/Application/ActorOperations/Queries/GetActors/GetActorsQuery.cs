using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Actors;

namespace WebApi.Application.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<ActorsViewModel> Handle()
        {
            var actors = _context.Actors
                .Include(x => x.MoviesOfActor)
                .ThenInclude(y => y.Movie)
                .OrderBy(x => x.Id)
                .ToList();

            return _mapper.Map<List<ActorsViewModel>>(actors);
        }
    }
}
