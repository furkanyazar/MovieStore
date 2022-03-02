using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Customers;

namespace WebApi.Application.CustomerOperations.Queries.GetCustomers
{
    public class GetCustomersQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<CustomersViewModel> Handle()
        {
            var customers = _context.Customers
                .Include(x => x.GenresOfCustomer)
                .ThenInclude(y => y.Genre)
                .Include(x => x.MoviesOfCustomer)
                .ThenInclude(y => y.Movie)
                .OrderBy(x => x.Id)
                .ToList();

            return _mapper.Map<List<CustomersViewModel>>(customers);
        }
    }
}
