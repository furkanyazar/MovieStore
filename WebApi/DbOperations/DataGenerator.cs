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
                        LastName = "Depp",
                        MovieIds = new List<int> { 1, 2 }
                    },
                    new Actor
                    {
                        FirstName = "Dwayne",
                        LastName = "Johnson",
                        MovieIds = new List<int> { 3, 4 }
                    },
                    new Actor
                    {
                        FirstName = "Gal",
                        LastName = "Gadot",
                        MovieIds = new List<int> { 3 }
                    },
                    new Actor
                    {
                        FirstName = "Ryan",
                        LastName = "Reynolds",
                        MovieIds = new List<int> { 3 }
                    },
                    new Actor
                    {
                        FirstName = "Emily",
                        LastName = "Blunt",
                        MovieIds = new List<int> { 4 }
                    },
                    new Actor
                    {
                        FirstName = "Anne",
                        LastName = "Hathaway",
                        MovieIds = new List<int> { 2 }
                    },
                    new Actor
                    {
                        FirstName = "Deep",
                        LastName = "Roy",
                        MovieIds = new List<int> { 1 }
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
                        ActorIds = new List<int> { 1, 7 },
                        Price = 100,
                    },
                    new Movie
                    {
                        Name = "Alice's Adventures in Wonderland",
                        YearOfConstruction = new DateTime(2010, 2, 25),
                        GenreId = 2,
                        DirectorId = 1,
                        ActorIds = new List<int> { 1, 6 },
                        Price = 150,
                    },
                    new Movie
                    {
                        Name = "Red Notice",
                        YearOfConstruction = new DateTime(2021, 11, 4),
                        GenreId = 1,
                        DirectorId = 3,
                        ActorIds = new List<int> { 2, 3, 4 },
                        Price = 200,
                    },
                    new Movie
                    {
                        Name = "Jungle Cruise",
                        YearOfConstruction = new DateTime(2021, 7, 30),
                        GenreId = 3,
                        DirectorId = 2,
                        ActorIds = new List<int> { 2, 5 },
                        Price = 200,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
