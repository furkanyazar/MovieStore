using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Customers;

namespace WebApi.Application.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery
    {
        private readonly IMovieStoreDbContext _contex;
        private readonly IMapper _mapper;

        public int CustomerId { get; set; }

        public GetCustomerDetailQuery(IMovieStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public CustomerDetailViewModel Handle()
        {
            var customer = _contex.Customers
                .Include(x => x.GenresOfCustomer)
                .ThenInclude(y => y.Genre)
                .Include(x => x.MoviesOfCustomer)
                .ThenInclude(y => y.Movie)
                .SingleOrDefault(x => x.Id == CustomerId);

            if (customer is null) throw new InvalidOperationException("Müşteri bulunamadı");

            return _mapper.Map<CustomerDetailViewModel>(customer);
        }
    }
}
