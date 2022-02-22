using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Genre;
using WebApi.Models.User;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Genre
            CreateMap<CreateGenreModel, Genre>();
            CreateMap<UpdateGenreModel, Genre>();
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

            // User
            CreateMap<CreateUserModel, User>();
        }
    }
}
