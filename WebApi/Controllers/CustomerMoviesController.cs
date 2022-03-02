using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerMovieOperations.Commands.CreateCustomerMovie;
using WebApi.Application.CustomerMovieOperations.Commands.DeleteCustomerMovie;
using WebApi.Application.CustomerMovieOperations.Queries.GetCustomerMovies;
using WebApi.DbOperations;
using WebApi.Models.CustomerMovies;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerMoviesController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerMoviesController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomerMoviess()
        {
            GetCustomerMoviesQuery query = new GetCustomerMoviesQuery(_context, _mapper);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCustomerMovie([FromBody] CreateCustomerMovieModel newCustomerMovie)
        {
            CreateCustomerMovieCommand command = new CreateCustomerMovieCommand(_context, _mapper);
            command.Model = newCustomerMovie;

            CreateCustomerMovieCommandValidator validator = new CreateCustomerMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerMovie(int id)
        {
            DeleteCustomerMovieCommand command = new DeleteCustomerMovieCommand(_context);
            command.CustomerMovieId = id;

            DeleteCustomerMovieCommandValidator validator = new DeleteCustomerMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
