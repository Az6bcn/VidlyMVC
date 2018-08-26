using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.API
{
    [Authorize(Roles = RoleName.CanManagerMovies)]
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [AllowAnonymous]
        [Route("api/movies/GetMovies")]
        [HttpGet]
        public IEnumerable<MovieDTO> GetMovies(string query = null)
        {
            var moviesQuery = _dbContext.Movies.Include(x => x.Genre);

            if (!string.IsNullOrWhiteSpace(query))

                moviesQuery = moviesQuery.Where(x => (x.Name.Contains(query) && x.NumberAvailable > 0));


            var response = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDTO>);

            return response;

        }

        [AllowAnonymous]
        [Route("api/movies/GetMovie/{Id}")]
        [HttpGet]
        public IHttpActionResult GetMovieById(int Id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == Id);

            if (movie == null) { return NotFound(); }

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }


        [Route("api/movies/CreateMovie")]
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO moviedto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDTO, Movie>(moviedto);

            _dbContext.Movies.Add(movie);

            _dbContext.SaveChanges();

            moviedto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviedto);
        }



        [Route("api/movies/UpdateMovie/{Id}")]
        [HttpPut]
        public void UpdateMovie(int Id, MovieDTO moviedto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDB = _dbContext.Movies.Single(x => x.Id == Id);

            if (movieInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<MovieDTO, Movie>(moviedto, movieInDB);
           
            
            _dbContext.SaveChanges();

        }



        [Route("api/movies/DeleteMovie/{id}")]
        [HttpDelete]
        public void DeleteMovie(int Id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDB = _dbContext.Movies.Single(x => x.Id == Id);

            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _dbContext.Movies.Remove(customerInDB);

            _dbContext.SaveChanges();
        }

    }
    
}
