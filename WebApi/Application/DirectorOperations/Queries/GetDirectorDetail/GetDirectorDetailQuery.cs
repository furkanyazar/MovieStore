using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models.Directors;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        private readonly IMovieStoreDbContext _contex;
        private readonly IMapper _mapper;

        public int DirectorId { get; set; }

        public GetDirectorDetailQuery(IMovieStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public DirectorDetailViewModel Handle()
        {
            var director = _contex.Directors
                .Include(x => x.MoviesOfDirector)
                .ThenInclude(y => y.Movie)
                .SingleOrDefault(x => x.Id == DirectorId);

            if (director is null) throw new InvalidOperationException("Yönetmen bulunamadı");

            return _mapper.Map<DirectorDetailViewModel>(director);
        }
    }
}
