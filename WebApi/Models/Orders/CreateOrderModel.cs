using System;

namespace WebApi.Models.Orders
{
    public class CreateOrderModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfOrder { get; set; }
    }
}
