using NUnit.Framework;
using WebApplication1;
using WebApplication1.ExternalAPI;
using WebApplication1.MiddleWare;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace Tests
{
    public class CinemaWorldMoviePrice : Config
    {
        [SetUp]
        
        public void Setup()
        {

        }

        /* CinemaWorld random movie id */
        [Test]
        public void Test1()
        {
            var config = InitConfiguration();
            Provider provider = Provider.CinemaWorld;
            string id = "cw0091234";
            CinemaWorld cinemaWorld = new CinemaWorld(config.GetSection("CinemaWorldApi").Value, config.GetSection("CinemaWorldAccessToken").Value);
            FilmWorld filmWorld = new FilmWorld(config.GetSection("FilmWorldApi").Value, config.GetSection("FilmWorldAccessToken").Value);
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            Decimal price = im.MoviePrice(provider, id).Result;
            Assert.AreEqual(-1, price);
        }

        /* CinemaWorld empty movie id */
        [Test]
        public void Test2()
        {
            var config = InitConfiguration();
            Provider provider = Provider.CinemaWorld;
            string id = "";
            CinemaWorld cinemaWorld = new CinemaWorld(config.GetSection("CinemaWorldApi").Value, config.GetSection("CinemaWorldAccessToken").Value);
            FilmWorld filmWorld = new FilmWorld(config.GetSection("FilmWorldApi").Value, config.GetSection("FilmWorldAccessToken").Value);
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            Decimal price = im.MoviePrice(provider, id).Result;
            Assert.AreEqual(-1, price);
        }

        /* CinemaWorld valid movie id */
        [Test]
        public void Test7()
        {
            var config = InitConfiguration();
            Provider provider = Provider.CinemaWorld;
            string id = "cw0080684";
            CinemaWorld cinemaWorld = new CinemaWorld(config.GetSection("CinemaWorldApi").Value, config.GetSection("CinemaWorldAccessToken").Value);
            FilmWorld filmWorld = new FilmWorld(config.GetSection("FilmWorldApi").Value, config.GetSection("FilmWorldAccessToken").Value);
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            Decimal price = im.MoviePrice(provider, id).Result;
            Assert.AreEqual(13.5, price);
        }

        /* CinemaWorld valid movie id */
        [Test]
        public void Test8()
        {
            var config = InitConfiguration();
            Provider provider = Provider.CinemaWorld;
            string id = "cw0076759";
            CinemaWorld cinemaWorld = new CinemaWorld(config.GetSection("CinemaWorldApi").Value, config.GetSection("CinemaWorldAccessToken").Value);
            FilmWorld filmWorld = new FilmWorld(config.GetSection("FilmWorldApi").Value, config.GetSection("FilmWorldAccessToken").Value);
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            Decimal price = im.MoviePrice(provider, id).Result;
            Assert.AreEqual(123.5, price);
        }

        /* CinemaWorld random movie id with spl chars */
        [Test]
        public void Test10()
        {
            var config = InitConfiguration();
            Provider provider = Provider.CinemaWorld;
            string id = "1l./;-=o";
            CinemaWorld cinemaWorld = new CinemaWorld(config.GetSection("CinemaWorldApi").Value, config.GetSection("CinemaWorldAccessToken").Value);
            FilmWorld filmWorld = new FilmWorld(config.GetSection("FilmWorldApi").Value, config.GetSection("FilmWorldAccessToken").Value);
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            Decimal price = im.MoviePrice(provider, id).Result;
            Assert.AreEqual(-1, price);
        }
    }
}