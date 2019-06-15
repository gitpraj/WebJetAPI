using NUnit.Framework;
using WebApplication1;
using WebApplication1.ExternalAPI;
using WebApplication1.MiddleWare;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class AllMovies
    {
        [SetUp]

        public void Setup()
        {

        }

        /* movies that have "Star Wars". This test checks the number of movies that are returned  */
        [Test]
        public void Test1()
        {
            IEnumerable<MovieSummary> movies;
            CinemaWorld cinemaWorld = new CinemaWorld("http://webjetapitest.azurewebsites.net/api/cinemaworld/", "sjd1HfkjU83ksdsm3802k");
            FilmWorld filmWorld = new FilmWorld("http://webjetapitest.azurewebsites.net/api/filmworld/", "sjd1HfkjU83ksdsm3802k");
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            movies = im.FindMovies("Star Wars").Result;

            List<MovieSummary> movieList = movies.ToList();
            int count = movieList.Count();
            Assert.AreEqual(13, count);
        }

        /* movies that have "John wick". This test checks the number of movies that are returned  */
        [Test]
        public void Test2()
        {
            IEnumerable<MovieSummary> movies;
            CinemaWorld cinemaWorld = new CinemaWorld("http://webjetapitest.azurewebsites.net/api/cinemaworld/", "sjd1HfkjU83ksdsm3802k");
            FilmWorld filmWorld = new FilmWorld("http://webjetapitest.azurewebsites.net/api/filmworld/", "sjd1HfkjU83ksdsm3802k");
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            movies = im.FindMovies("John wick").Result;

            List<MovieSummary> movieList = movies.ToList();
            int count = movieList.Count();
            Assert.AreEqual(0, count);
        }

        /* movies that have "new hope". This test checks the number of movies that are returned  */
        [Test]
        public void Test3()
        {
            IEnumerable<MovieSummary> movies;
            CinemaWorld cinemaWorld = new CinemaWorld("http://webjetapitest.azurewebsites.net/api/cinemaworld/", "sjd1HfkjU83ksdsm3802k");
            FilmWorld filmWorld = new FilmWorld("http://webjetapitest.azurewebsites.net/api/filmworld/", "sjd1HfkjU83ksdsm3802k");
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            movies = im.FindMovies("new hope").Result;

            List<MovieSummary> movieList = movies.ToList();
            int count = movieList.Count();
            Assert.AreEqual(2, count);
        }
    }
}