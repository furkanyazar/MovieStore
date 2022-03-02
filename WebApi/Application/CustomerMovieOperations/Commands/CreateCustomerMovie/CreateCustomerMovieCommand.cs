using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Models.CustomerMovies;

namespace WebApi.Application.CustomerMovieOperations.Commands.CreateCustomerMovie
{
    public class CreateCustomerMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerMovieModel Model { get; set; }

        public CreateCustomerMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customerMovie = _context.CustomerMovies.SingleOrDefault(x => x.CustomerId == Model.CustomerId && x.MovieId == Model.MovieId);

            if (customerMovie is not null) throw new InvalidOperationException("Zaten mevcut");

            customerMovie = _mapper.Map<CustomerMovie>(Model);

            _context.CustomerMovies.Add(customerMovie);
            _context.SaveChanges();
        }
    }
}
