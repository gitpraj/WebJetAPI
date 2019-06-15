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
    public class FilmWorldMoviePrice
    {
        [SetUp]

        public void Setup()
        {

        }

        /* FilmWorld random movie id */
        [Test]
        public void Test3()
        {
            Provider provider = Provider.FilmWorld;
            string id = "fw0091234";
            CinemaWorld cinemaWorld = new CinemaWorld("http://webjetapitest.azurewebsites.net/api/cinemaworld/", "sjd1HfkjU83ksdsm3802k");
            FilmWorld filmWorld = new FilmWorld("http://webjetapitest.azurewebsites.net/api/filmworld/", "sjd1HfkjU83ksdsm3802k");
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            Decimal price = im.MoviePrice(provider, id).Result;
            Assert.AreEqual(-1, price);
        }

        /* FilmWorld empty movie id */
        [Test]
        public void Test4()
        {
            Provider provider = Provider.FilmWorld;
            string id = "";
            CinemaWorld cinemaWorld = new CinemaWorld("http://webjetapitest.azurewebsites.net/api/cinemaworld/", "sjd1HfkjU83ksdsm3802k");
            FilmWorld filmWorld = new FilmWorld("http://webjetapitest.azurewebsites.net/api/filmworld/", "sjd1HfkjU83ksdsm3802k");
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            Decimal price = im.MoviePrice(provider, id).Result;
            Assert.AreEqual(-1, price);
        }

        /* FilmWorld valid movie id */
        [Test]
        public void Test5()
        {
            Provider provider = Provider.FilmWorld;
            string id = "fw0076759";
            CinemaWorld cinemaWorld = new CinemaWorld("http://webjetapitest.azurewebsites.net/api/cinemaworld/", "sjd1HfkjU83ksdsm3802k");
            FilmWorld filmWorld = new FilmWorld("http://webjetapitest.azurewebsites.net/api/filmworld/", "sjd1HfkjU83ksdsm3802k");
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            Decimal price = im.MoviePrice(provider, id).Result;
            Assert.AreEqual(29.5, price);
        }

        /* FilmWorld valid movie id */
        [Test]
        public void Test6()
        {
            Provider provider = Provider.FilmWorld;
            string id = "fw0080684";
            CinemaWorld cinemaWorld = new CinemaWorld("http://webjetapitest.azurewebsites.net/api/cinemaworld/", "sjd1HfkjU83ksdsm3802k");
            FilmWorld filmWorld = new FilmWorld("http://webjetapitest.azurewebsites.net/api/filmworld/", "sjd1HfkjU83ksdsm3802k");
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            Decimal price = im.MoviePrice(provider, id).Result;
            Assert.AreEqual(1295, price);
        }

        /* FilmWorld random movie id with spl chars */
        [Test]
        public void Test9()
        {
            Provider provider = Provider.FilmWorld;
            string id = "-1op,l;";
            CinemaWorld cinemaWorld = new CinemaWorld("http://webjetapitest.azurewebsites.net/api/cinemaworld/", "sjd1HfkjU83ksdsm3802k");
            FilmWorld filmWorld = new FilmWorld("http://webjetapitest.azurewebsites.net/api/filmworld/", "sjd1HfkjU83ksdsm3802k");
            Intermediary im = new Intermediary(cinemaWorld, filmWorld);
            Decimal price = im.MoviePrice(provider, id).Result;
            Assert.AreEqual(-1, price);
        }
    }
}