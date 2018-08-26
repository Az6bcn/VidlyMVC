using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.API
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public NewRentalController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDTO newRental)
        {
            if (newRental.MovieIDs.Count == 0) { return BadRequest("No MovieIds"); }

            var customer = _dbContext.Customers.FirstOrDefault(c => c.ID == newRental.CustomerID);

            if(customer == null){
                return BadRequest("Invalid CustomerID");
            }

            var movies = _dbContext.Movies.Where(x => newRental.MovieIDs.Contains(x.Id)).ToList(); // select * from movies where Id in (list of IDs in newRental)

            if (movies.Count != newRental.MovieIDs.Count) { return BadRequest("One or More MovieIds are invalid"); }

            foreach (var movie in movies)
            {

                //movie not avDefault1ailaible
                if (movie.NumberAvailable == 0) { return BadRequest("Movie not available"); }

                var rentalModel = new Rental
                {
                    Customer = customer,
                    CustomerID = newRental.CustomerID,
                    Movie = movie,
                    //MovieID = movie.Id,
                    DateRented = DateTime.Now
                };

                movie.NumberAvailable = movie.NumberAvailable - 1;
                _dbContext.Rentals.Add(rentalModel);
            }

            _dbContext.SaveChanges();

            return Ok();
        }


    }
}
