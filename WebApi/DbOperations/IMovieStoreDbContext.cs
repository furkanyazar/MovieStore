using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Actor> Actors { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<ActorMovie> ActorMovies { get; set; }
        DbSet<DirectorMovie> DirectorMovies { get; set; }
        DbSet<CustomerGenre> CustomerGenres { get; set; }
        DbSet<CustomerMovie> CustomerMovies { get; set; }

        int SaveChanges();
    }
}
