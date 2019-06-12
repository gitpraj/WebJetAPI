using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ExternalAPI;
using WebApplication1.Models;
using WebApplication1.MiddleWare;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult GetMovie(String searchTerm)
        {
            //CinemaWorld cw = new CinemaWorld("http://webjetapitest.azurewebsites.net/api/cinemaworld/", "sjd1HfkjU83ksdsm3802k");
            IEnumerable<MovieSummary> movies;
            //movies = cw.MovieSearch("John").Result;
            CinemaWorld cinemaWorld = new CinemaWorld("http://webjetapitest.azurewebsites.net/api/cinemaworld/", "sjd1HfkjU83ksdsm3802k");
            FilmWorld filmWorld = new FilmWorld("http://webjetapitest.azurewebsites.net/api/filmworld/", "sjd1HfkjU83ksdsm3802k");
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            movies = im.FindMovies(searchTerm).Result;
            return Ok(movies);
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
