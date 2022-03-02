using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.DirectorMovies;

namespace WebApi.Application.DirectorMovieOperations.Queries.GetDirectorMovies
{
    public class GetDirectorMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<DirectorMoviesViewModel> Handle()
        {
            var directorMovies = _context.DirectorMovies
                .Include(x => x.Director)
                .Include(x => x.Movie)
                .OrderBy(x => x.Id)
                .ToList();

            return _mapper.Map<List<DirectorMoviesViewModel>>(directorMovies);
        }
    }
}
