using AutoMapper;
using WebApi.Entities;
using WebApi.Models.ActorMovies;
using WebApi.Models.Actors;
using WebApi.Models.CustomerGenres;
using WebApi.Models.Customers;
using WebApi.Models.Directors;
using WebApi.Models.Genres;
using WebApi.Models.Movies;
using WebApi.Models.Orders;
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

            // Movie
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<UpdateMovieModel, Movie>();
            CreateMap<Actor, ActorMovie>()
                .ForMember(dest => dest.ActorId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Actor, opt => opt.MapFrom(src => src));
            CreateMap<Movie, MoviesViewModel>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.FullName))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.ActorsOfMovie, opt => opt.MapFrom(src => src.ActorsOfMovie))
                .AfterMap((src, dest) =>
                {
                    dest.ActorsOfMovie.Clear();
                    foreach (var item in src.ActorsOfMovie) dest.ActorsOfMovie.Add(item.Actor.FullName);
                });
            CreateMap<Actor, ActorMovie>()
                .ForMember(dest => dest.ActorId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Actor, opt => opt.MapFrom(src => src));
            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.FullName))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.ActorsOfMovie, opt => opt.MapFrom(src => src.ActorsOfMovie))
                .AfterMap((src, dest) =>
                {
                    dest.ActorsOfMovie.Clear();
                    foreach (var item in src.ActorsOfMovie) dest.ActorsOfMovie.Add(item.Actor.FullName);
                });

            // Order
            CreateMap<CreateOrderModel, Order>();
            CreateMap<UpdateOrderModel, Order>();
            CreateMap<Order, OrdersViewModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Name));
            CreateMap<Order, OrderDetailViewModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Name));

            // Customer
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<UpdateCustomerModel, Customer>();
            CreateMap<Genre, CustomerGenre>()
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src));
            CreateMap<Movie, CustomerMovie>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src));
            CreateMap<Customer, CustomersViewModel>()
                .ForMember(dest => dest.MoviesOfCustomer, opt => opt.MapFrom(src => src.MoviesOfCustomer))
                .AfterMap((src, dest) =>
                {
                    dest.MoviesOfCustomer.Clear();
                    foreach (var item in src.MoviesOfCustomer) dest.MoviesOfCustomer.Add(item.Movie.Name);
                })
                .ForMember(dest => dest.GenresOfCustomer, opt => opt.MapFrom(src => src.GenresOfCustomer))
                .AfterMap((src, dest) =>
                {
                    dest.GenresOfCustomer.Clear();
                    foreach (var item in src.GenresOfCustomer) if (item.Genre.IsActive) dest.GenresOfCustomer.Add(item.Genre.Name);
                });
            CreateMap<Genre, CustomerGenre>()
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src));
            CreateMap<Movie, CustomerMovie>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src));
            CreateMap<Customer, CustomerDetailViewModel>()
                .ForMember(dest => dest.MoviesOfCustomer, opt => opt.MapFrom(src => src.MoviesOfCustomer))
                .AfterMap((src, dest) =>
                {
                    dest.MoviesOfCustomer.Clear();
                    foreach (var item in src.MoviesOfCustomer) dest.MoviesOfCustomer.Add(item.Movie.Name);
                })
                .ForMember(dest => dest.GenresOfCustomer, opt => opt.MapFrom(src => src.GenresOfCustomer))
                .AfterMap((src, dest) =>
                {
                    dest.GenresOfCustomer.Clear();
                    foreach (var item in src.GenresOfCustomer) if (item.Genre.IsActive) dest.GenresOfCustomer.Add(item.Genre.Name);
                });

            // ActorMovie
            CreateMap<CreateActorMovieModel, ActorMovie>();
            CreateMap<ActorMovie, ActorMoviesViewModel>()
                .ForMember(dest => dest.Actor, opt => opt.MapFrom(src => src.Actor.FullName))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Name));

            // CustomerGenre
            CreateMap<CreateCustomerGenreModel, CustomerGenre>();
            CreateMap<CustomerGenre, CustomerGenresViewModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
        }
    }
}
