using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly IMovieStoreDbContext _contex;
        private readonly IMapper _mapper;

        public int GenreId { get; set; }

        public GetGenreDetailQuery(IMovieStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _contex.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);

            if (genre is null) throw new InvalidOperationException("Film türü bulunamadı");

            return _mapper.Map<GenreDetailViewModel>(genre);
        }
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
