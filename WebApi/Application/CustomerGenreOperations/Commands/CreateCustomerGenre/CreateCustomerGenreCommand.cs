using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Models.CustomerGenres;

namespace WebApi.Application.CustomerGenreOperations.Commands.CreateCustomerGenre
{
    public class CreateCustomerGenreCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerGenreModel Model { get; set; }

        public CreateCustomerGenreCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customerGenre = _context.CustomerGenres.SingleOrDefault(x => x.CustomerId == Model.CustomerId && x.GenreId == Model.GenreId);

            if (customerGenre is not null) throw new InvalidOperationException("Zaten mevcut");

            customerGenre = _mapper.Map<CustomerGenre>(Model);

            _context.CustomerGenres.Add(customerGenre);
            _context.SaveChanges();
        }
    }
}
