using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ExternalAPI;
using WebApplication1.Models;
using WebApplication1.MiddleWare;
using WebApplication1.Interfaces;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        public MoviesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [HttpGet("[action]")]
        public IActionResult GetMovie(String searchTerm)
        {
            try
            {
                IEnumerable<MovieSummary> movies;
                CinemaWorld cinemaWorld = new CinemaWorld(Configuration.GetSection("CinemaWorldApi").Value, Configuration.GetSection("CinemaWorldAccessToken").Value);
                FilmWorld filmWorld = new FilmWorld(Configuration.GetSection("FilmWorldApi").Value, Configuration.GetSection("FilmWorldAccessToken").Value);
                Intermediary im = new Intermediary(cinemaWorld, filmWorld);
                movies = im.FindMovies(searchTerm).Result;
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Movie Not Found" }) { StatusCode = 500 };
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetMoviePrice(Provider provider, String id)
        {
            try
            {
                Decimal price;
                CinemaWorld cinemaWorld = new CinemaWorld(Configuration.GetSection("CinemaWorldApi").Value, Configuration.GetSection("CinemaWorldAccessToken").Value);
                FilmWorld filmWorld = new FilmWorld(Configuration.GetSection("FilmWorldApi").Value, Configuration.GetSection("FilmWorldAccessToken").Value);
                Intermediary im = new Intermediary(cinemaWorld, filmWorld);
                price = im.MoviePrice(provider, id).Result;
                return Ok(price);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Price for the movie not found" }) { StatusCode = 500 };
            }
        }
    }
}
