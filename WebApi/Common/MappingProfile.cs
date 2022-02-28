using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Actors;
using WebApi.Models.Directors;
using WebApi.Models.Genres;
using WebApi.Models.Users;

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

            // Actor
            CreateMap<CreateActorModel, Actor>();
            CreateMap<UpdateActorModel, Actor>();
            CreateMap<Movie, ActorMovie>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src));
            CreateMap<Actor, ActorsViewModel>()
                .ForMember(dest => dest.MoviesOfActor, opt => opt.MapFrom(src => src.MoviesOfActor))
                .AfterMap((src, dest) =>
                {
                    dest.MoviesOfActor.Clear();
                    foreach (var item in src.MoviesOfActor) dest.MoviesOfActor.Add(item.Movie.Name);
                });
            CreateMap<Movie, ActorMovie>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src));
            CreateMap<Actor, ActorDetailViewModel>()
                .ForMember(dest => dest.MoviesOfActor, opt => opt.MapFrom(src => src.MoviesOfActor))
                .AfterMap((src, dest) =>
                {
                    dest.MoviesOfActor.Clear();
                    foreach (var item in src.MoviesOfActor) dest.MoviesOfActor.Add(item.Movie.Name);
                });

            // Director
            CreateMap<CreateDirectorModel, Director>();
            CreateMap<UpdateDirectorModel, Director>();
            CreateMap<Movie, DirectorMovie>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src));
            CreateMap<Director, DirectorsViewModel>()
                .ForMember(dest => dest.MoviesOfDirector, opt => opt.MapFrom(src => src.MoviesOfDirector))
                .AfterMap((src, dest) =>
                {
                    dest.MoviesOfDirector.Clear();
                    foreach (var item in src.MoviesOfDirector) dest.MoviesOfDirector.Add(item.Movie.Name);
                });
            CreateMap<Movie, DirectorMovie>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src));
            CreateMap<Director, DirectorDetailViewModel>()
                .ForMember(dest => dest.MoviesOfDirector, opt => opt.MapFrom(src => src.MoviesOfDirector))
                .AfterMap((src, dest) =>
                {
                    dest.MoviesOfDirector.Clear();
                    foreach (var item in src.MoviesOfDirector) dest.MoviesOfDirector.Add(item.Movie.Name);
                });
        }
    }
}
