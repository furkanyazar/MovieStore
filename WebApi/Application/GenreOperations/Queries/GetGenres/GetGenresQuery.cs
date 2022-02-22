using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Name).ToList();

            return _mapper.Map<List<GenresViewModel>>(genres);
        }
    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
