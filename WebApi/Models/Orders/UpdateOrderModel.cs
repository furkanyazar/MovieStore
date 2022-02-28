using System;

namespace WebApi.Models.Orders
{
    public class UpdateOrderModel
    {
        public decimal Price { get; set; }
        public DateTime DateOfOrder { get; set; }
    }
}
