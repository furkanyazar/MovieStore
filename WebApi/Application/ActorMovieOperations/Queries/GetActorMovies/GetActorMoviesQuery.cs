using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.ActorMovies;

namespace WebApi.Application.ActorMovieOperations.Queries.GetActorMovies
{
    public class GetActorMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<ActorMoviesViewModel> Handle()
        {
            var actorMovies = _context.ActorMovies
                .Include(x => x.Actor)
                .Include(x => x.Movie)
                .OrderBy(x => x.Id)
                .ToList();

            return _mapper.Map<List<ActorMoviesViewModel>>(actorMovies);
        }
    }
}
