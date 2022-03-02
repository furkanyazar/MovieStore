using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.CustomerMovies;

namespace WebApi.Application.CustomerMovieOperations.Queries.GetCustomerMovies
{
    public class GetCustomerMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<CustomerMoviesViewModel> Handle()
        {
            var customerMovies = _context.CustomerMovies
                .Include(x => x.Customer)
                .Include(x => x.Movie)
                .OrderBy(x => x.Id)
                .ToList();

            return _mapper.Map<List<CustomerMoviesViewModel>>(customerMovies);
        }
    }
}
