﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.MiddleWare;
using WebApplication1.Models;

namespace WebApplication1.ExternalAPI
{
    public class CinemaWorld : APICall
    {
        public CinemaWorld(string _apiUrl, string _accessToken)
        {
            apiUrl = _apiUrl;
            accessToken = _accessToken;
        }

        public CinemaWorld()
        {
        }

        public override async Task<IEnumerable<MovieSummary>> MovieSearch(string searchTerm)
        {
            var response = await CallExtAPI(apiUrl + "movies", accessToken);
            JObject json;
            JArray jsonArr;
            List<MovieSummary> moviesList;
            if (response == "")
            {
                /* error handle */
            }

            json = JObject.Parse(response);
            jsonArr = JArray.Parse(json["Movies"].ToString());
            moviesList = JsonConvert.DeserializeObject<List<MovieSummary>>(jsonArr.ToString());
            var movies = moviesList.Where(m => m.Title.ToLower().Contains(searchTerm.ToLower(), StringComparison.OrdinalIgnoreCase)).ToList(); // Filter by searchTerm
            movies.ForEach(m => { m.Provider = "CinemaWorld"; });

            return movies;
        }

        public async Task<MovieDetails> GetMovieDetails(string id)
        {
            //var response = await GetAsync<MovieDetails>($"movie/{id}");
            var response = await CallExtAPI(apiUrl + "movie/" + id, accessToken);
            //var movie = response.Data;

            JObject json;
            MovieDetails movie;
            if (response == "")
            {
                /* error handle */
            }

            //json = JObject.Parse(response);
            movie = JsonConvert.DeserializeObject<MovieDetails>(response);
            //var movie = moviesList; // Filter by searchTerm
            //movies.ForEach(m => { m.Provider = Provider; }); // Set the Provider

            return movie;
        }

        public async Task<decimal> GetMoviePrice(string movieId)
        {
            var movie = await GetMovieDetails(movieId);
            return movie.Price;
        }
    }
}
