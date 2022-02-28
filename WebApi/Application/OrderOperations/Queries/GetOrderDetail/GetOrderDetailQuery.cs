using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Orders;

namespace WebApi.Application.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery
    {
        private readonly IMovieStoreDbContext _contex;
        private readonly IMapper _mapper;

        public int OrderId { get; set; }

        public GetOrderDetailQuery(IMovieStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public OrderDetailViewModel Handle()
        {
            var order = _contex.Orders
                .Include(x => x.Customer)
                .Include(x => x.Movie)
                .SingleOrDefault(x => x.Id == OrderId);

            if (order is null) throw new InvalidOperationException("Sipariş bulunamadı");

            return _mapper.Map<OrderDetailViewModel>(order);
        }
    }
}
