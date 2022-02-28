using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Models.Orders;

namespace WebApi.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderModel Model { get; set; }

        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(x => x.CutomerId == Model.CustomerId && x.MovieId == Model.MovieId);

            if (order is not null) throw new InvalidOperationException("Sipariş zaten mevcut");

            order = _mapper.Map<Order>(Model);

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
