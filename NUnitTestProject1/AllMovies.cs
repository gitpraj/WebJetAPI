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
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace Tests
{
    public class AllMovies : Config
    {
        [SetUp]
        public void Setup()
        {
        }

        /* movies that have "Star Wars". This test checks the number of movies that are returned  */
        [Test]
        public void Test1()
        {
            var config = InitConfiguration();
            IEnumerable<MovieSummary> movies;
            CinemaWorld cinemaWorld = new CinemaWorld(config.GetSection("CinemaWorldApi").Value, config.GetSection("CinemaWorldAccessToken").Value);
            FilmWorld filmWorld = new FilmWorld(config.GetSection("FilmWorldApi").Value, config.GetSection("FilmWorldAccessToken").Value);
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
            var config = InitConfiguration();
            IEnumerable<MovieSummary> movies;
            CinemaWorld cinemaWorld = new CinemaWorld(config.GetSection("CinemaWorldApi").Value, config.GetSection("CinemaWorldAccessToken").Value);
            FilmWorld filmWorld = new FilmWorld(config.GetSection("FilmWorldApi").Value, config.GetSection("FilmWorldAccessToken").Value);
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
            var config = InitConfiguration();
            IEnumerable<MovieSummary> movies;
            CinemaWorld cinemaWorld = new CinemaWorld(config.GetSection("CinemaWorldApi").Value, config.GetSection("CinemaWorldAccessToken").Value);
            FilmWorld filmWorld = new FilmWorld(config.GetSection("FilmWorldApi").Value, config.GetSection("FilmWorldAccessToken").Value);
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            movies = im.FindMovies("new hope").Result;

            List<MovieSummary> movieList = movies.ToList();
            int count = movieList.Count();
            Assert.AreEqual(2, count);
        }
    }
}