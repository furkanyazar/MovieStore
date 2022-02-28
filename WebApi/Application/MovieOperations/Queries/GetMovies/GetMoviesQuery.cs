using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Movies;

namespace WebApi.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<MoviesViewModel> Handle()
        {
            var movies = _context.Movies
                .Include(x => x.Director)
                .Include(x => x.Genre)
                .Include(x => x.ActorsOfMovie)
                .ThenInclude(y => y.Actor)
                .OrderBy(x => x.Id)
                .ToList();

            return _mapper.Map<List<MoviesViewModel>>(movies);
        }
    }
}
