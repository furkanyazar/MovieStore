using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Orders;

namespace WebApi.Application.OrderOperations.Queries.GetOrders
{
    public class GetOrdersQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OrdersViewModel> Handle()
        {
            var orders = _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Movie)
                .ToList();

            return _mapper.Map<List<OrdersViewModel>>(orders);
        }
    }
}
