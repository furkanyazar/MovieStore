using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerGenreOperations.Commands.CreateCustomerGenre;
using WebApi.Application.CustomerGenreOperations.Commands.DeleteCustomerGenre;
using WebApi.Application.CustomerGenreOperations.Queries.GetCustomerGenres;
using WebApi.DbOperations;
using WebApi.Models.CustomerGenres;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerGenresController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerGenresController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomerGenress()
        {
            GetCustomerGenresQuery query = new GetCustomerGenresQuery(_context, _mapper);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCustomerGenre([FromBody] CreateCustomerGenreModel newCustomerGenre)
        {
            CreateCustomerGenreCommand command = new CreateCustomerGenreCommand(_context, _mapper);
            command.Model = newCustomerGenre;

            CreateCustomerGenreCommandValidator validator = new CreateCustomerGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerGenre(int id)
        {
            DeleteCustomerGenreCommand command = new DeleteCustomerGenreCommand(_context);
            command.CustomerGenreId = id;

            DeleteCustomerGenreCommandValidator validator = new DeleteCustomerGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
