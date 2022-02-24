using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Actors.Any() && context.Directors.Any() && context.Genres.Any() && context.Movies.Any()) return;

                context.Actors.AddRange(
                    new Actor
                    {
                        FirstName = "Johnny",
                        LastName = "Depp"
                    },
                    new Actor
                    {
                        FirstName = "Dwayne",
                        LastName = "Johnson"
                    },
                    new Actor
                    {
                        FirstName = "Gal",
                        LastName = "Gadot"
                    },
                    new Actor
                    {
                        FirstName = "Ryan",
                        LastName = "Reynolds"
                    },
                    new Actor
                    {
                        FirstName = "Emily",
                        LastName = "Blunt"
                    },
                    new Actor
                    {
                        FirstName = "Anne",
                        LastName = "Hathaway"
                    },
                    new Actor
                    {
                        FirstName = "Deep",
                        LastName = "Roy"
                    }
                );

                context.Directors.AddRange(
                    new Director
                    {
                        FirstName = "Tim",
                        LastName = "Burton",
                        MovieIds = new List<int> { 1, 2 }
                    },
                    new Director
                    {
                        FirstName = "Jaume",
                        LastName = "Collet-Serra",
                        MovieIds = new List<int> { 4 }
                    },
                    new Director
                    {
                        FirstName = "Rawson Marshall",
                        LastName = "Thurber",
                        MovieIds = new List<int> { 3 }
                    }
                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Aksiyon"
                    },
                    new Genre
                    {
                        Name = "Fantastik"
                    },
                    new Genre
                    {
                        Name = "Macera"
                    }
                );

                context.Movies.AddRange(
                    new Movie
                    {
                        Name = "Charlie and the Chocolate Factory",
                        YearOfConstruction = new DateTime(2005, 8, 12),
                        GenreId = 2,
                        DirectorId = 1,
                        Price = 100
                    },
                    new Movie
                    {
                        Name = "Alice's Adventures in Wonderland",
                        YearOfConstruction = new DateTime(2010, 2, 25),
                        GenreId = 2,
                        DirectorId = 1,
                        Price = 150
                    },
                    new Movie
                    {
                        Name = "Red Notice",
                        YearOfConstruction = new DateTime(2021, 11, 4),
                        GenreId = 1,
                        DirectorId = 3,
                        Price = 200
                    },
                    new Movie
                    {
                        Name = "Jungle Cruise",
                        YearOfConstruction = new DateTime(2021, 7, 30),
                        GenreId = 3,
                        DirectorId = 2,
                        Price = 250
                    }
                );

                context.ActorsMovies.AddRange(
                    new ActorMovie
                    {
                        MovieId = 1,
                        ActorId = 1
                    },
                    new ActorMovie
                    {
                        MovieId = 1,
                        ActorId = 7
                    },
                    new ActorMovie
                    {
                        MovieId = 2,
                        ActorId = 1
                    },
                    new ActorMovie
                    {
                        MovieId = 2,
                        ActorId = 6
                    },
                    new ActorMovie
                    {
                        MovieId = 3,
                        ActorId = 2
                    },
                    new ActorMovie
                    {
                        MovieId = 3,
                        ActorId = 3
                    },
                    new ActorMovie
                    {
                        MovieId = 3,
                        ActorId = 4
                    },
                    new ActorMovie
                    {
                        MovieId = 4,
                        ActorId = 2
                    },
                    new ActorMovie
                    {
                        MovieId = 4,
                        ActorId = 5
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
