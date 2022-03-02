using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorMovieOperations.Commands.CreateActorMovie;
using WebApi.Application.ActorMovieOperations.Commands.DeleteActorMovie;
using WebApi.Application.ActorMovieOperations.Queries.GetActorMovies;
using WebApi.DbOperations;
using WebApi.Models.ActorMovies;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorMoviesController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorMoviesController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActorMoviess()
        {
            GetActorMoviesQuery query = new GetActorMoviesQuery(_context, _mapper);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddActorMovie([FromBody] CreateActorMovieModel newActorMovie)
        {
            CreateActorMovieCommand command = new CreateActorMovieCommand(_context, _mapper);
            command.Model = newActorMovie;

            CreateActorMovieCommandValidator validator = new CreateActorMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActorMovie(int id)
        {
            DeleteActorMovieCommand command = new DeleteActorMovieCommand(_context);
            command.ActorMovieId = id;

            DeleteActorMovieCommandValidator validator = new DeleteActorMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
