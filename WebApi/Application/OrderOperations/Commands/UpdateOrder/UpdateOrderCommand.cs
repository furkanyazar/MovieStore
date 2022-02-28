using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models.Orders;

namespace WebApi.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int OrderId { get; set; }
        public UpdateOrderModel Model { get; set; }

        public UpdateOrderCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == OrderId);

            if (order is null) throw new InvalidOperationException("Sipariş bulunamadı");

            order.Price = Model.Price != default ? order.Price : Model.Price;
            order.DateOfOrder = Model.DateOfOrder;

            _context.SaveChanges();
        }
    }
}
