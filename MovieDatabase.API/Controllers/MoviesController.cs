using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.Models.ResourceModels;
using MovieDatabase.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase.API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository ?? throw new ArgumentException(nameof(movieRepository));
        }

        [HttpGet]
        public ActionResult<IQueryable<MovieResourceModel>> GetMovies()
        {
            var movies = movieRepository.GetAll();
            var movieViewModels = new List<MovieResourceModel>();

            foreach (var movie in movies)
            {
                movieViewModels.Add(new MovieResourceModel
                {
                    Id = movie.MovieId,
                    Title = movie.Title,
                    ReleaseYear = movie.ReleaseYear.ToShortDateString(),
                    IMDBRating = movie.Rating,
                    Directors = movie.MovieDirectors.Where(x => x.Movie.MovieId == movie.MovieId).Select(x=> $"{x.Director.FirstName} {x.Director.LastName}") //TODO: will be fixed
                });
            }

            return Ok(movieViewModels);
        }
    }
}