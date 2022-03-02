using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.CustomerGenres;

namespace WebApi.Application.CustomerGenreOperations.Queries.GetCustomerGenres
{
    public class GetCustomerGenresQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerGenresQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<CustomerGenresViewModel> Handle()
        {
            var customerGenres = _context.CustomerGenres
                .Include(x => x.Customer)
                .Include(x => x.Genre)
                .OrderBy(x => x.Id)
                .ToList();

            return _mapper.Map<List<CustomerGenresViewModel>>(customerGenres);
        }
    }
}
