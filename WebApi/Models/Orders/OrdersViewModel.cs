using System;

namespace WebApi.Models.Orders
{
    public class OrdersViewModel
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Movie { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfOrder { get; set; }
    }
}
