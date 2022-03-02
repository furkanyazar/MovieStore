using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DirectorMovieOperations.Commands.CreateDirectorMovie;
using WebApi.Application.DirectorMovieOperations.Commands.DeleteDirectorMovie;
using WebApi.Application.DirectorMovieOperations.Queries.GetDirectorMovies;
using WebApi.DbOperations;
using WebApi.Models.DirectorMovies;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorMoviesController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DirectorMoviesController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectorMoviess()
        {
            GetDirectorMoviesQuery query = new GetDirectorMoviesQuery(_context, _mapper);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDirectorMovie([FromBody] CreateDirectorMovieModel newDirectorMovie)
        {
            CreateDirectorMovieCommand command = new CreateDirectorMovieCommand(_context, _mapper);
            command.Model = newDirectorMovie;

            CreateDirectorMovieCommandValidator validator = new CreateDirectorMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirectorMovie(int id)
        {
            DeleteDirectorMovieCommand command = new DeleteDirectorMovieCommand(_context);
            command.DirectorMovieId = id;

            DeleteDirectorMovieCommandValidator validator = new DeleteDirectorMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
