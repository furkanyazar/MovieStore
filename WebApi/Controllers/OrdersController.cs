using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.Application.OrderOperations.Commands.DeleteOrder;
using WebApi.Application.OrderOperations.Commands.UpdateOrder;
using WebApi.Application.OrderOperations.Queries.GetOrderDetail;
using WebApi.Application.OrderOperations.Queries.GetOrders;
using WebApi.DbOperations;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public OrdersController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            GetOrdersQuery query = new GetOrdersQuery(_context, _mapper);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            query.OrderId = id;

            GetOrderDetailQueryValidator validator = new GetOrderDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var model = query.Handle();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] CreateOrderModel newOrder)
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = newOrder;

            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] UpdateOrderModel updatedOrder)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_context);
            command.OrderId = id;
            command.Model = updatedOrder;

            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.OrderId = id;

            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
