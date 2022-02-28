using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Actors;

namespace WebApi.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        private readonly IMovieStoreDbContext _contex;
        private readonly IMapper _mapper;

        public int ActorId { get; set; }

        public GetActorDetailQuery(IMovieStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public ActorDetailViewModel Handle()
        {
            var actor = _contex.Actors
                .Include(x => x.MoviesOfActor)
                .ThenInclude(y => y.Movie)
                .SingleOrDefault(x => x.Id == ActorId);

            if (actor is null) throw new InvalidOperationException("Oyuncu bulunamadı");

            return _mapper.Map<ActorDetailViewModel>(actor);
        }
    }
}
