using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Directors;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<DirectorsViewModel> Handle()
        {
            var actors = _context.Directors
                .Include(x => x.MoviesOfDirector)
                .ThenInclude(y => y.Movie)
                .OrderBy(x => x.Id)
                .ToList();

            return _mapper.Map<List<DirectorsViewModel>>(actors);
        }
    }
}
