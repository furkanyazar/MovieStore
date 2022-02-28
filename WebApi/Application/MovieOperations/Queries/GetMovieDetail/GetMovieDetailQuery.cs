using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Movies;

namespace WebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _contex;
        private readonly IMapper _mapper;

        public int MovieId { get; set; }

        public GetMovieDetailQuery(IMovieStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public MovieDetailViewModel Handle()
        {
            var movie = _contex.Movies
                .Include(x => x.Director)
                .Include(x => x.Genre)
                .Include(x => x.ActorsOfMovie)
                .ThenInclude(y => y.Actor)
                .SingleOrDefault(x => x.Id == MovieId);

            if (movie is null) throw new InvalidOperationException("Film bulunamadı");

            return _mapper.Map<MovieDetailViewModel>(movie);
        }
    }
}
