using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
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
            Provider = Provider.CinemaWorld;
        }

        public override async Task<IEnumerable<MovieSummary>> MovieSearchAsync(string searchTerm)
        {
            var response = await CallExtAPI(apiUrl + "movies", accessToken);
            JObject json;
            JArray jsonArr;
            List<MovieSummary> moviesList;
            ObjectCache cache = MemoryCache.Default;

            if (response == "")
            {
                /* error handle */
                string moviesCached = cache["cinemaWorldMovies"] as string;
                if (moviesCached != null)
                {
                    response = cache.Get("cinemaWorldMovies").ToString();
                }
            }
            else
            {
                string moviesCached = cache["cinemaWorldMovies"] as string;
                if (moviesCached == null)
                {
                    cache.Set("cinemaWorldMovies", response, null);
                }
            }

            json = JObject.Parse(response);
            jsonArr = JArray.Parse(json["Movies"].ToString());
            moviesList = JsonConvert.DeserializeObject<List<MovieSummary>>(jsonArr.ToString());
            var movies = moviesList.Where(m => m.Title.ToLower().Contains(searchTerm.ToLower(), StringComparison.OrdinalIgnoreCase)).ToList(); // Filter by searchTerm
            movies.ForEach(m => { m.Provider = Provider.CinemaWorld; });

            return movies;
        }

        public override async Task<decimal> GetMoviePriceAsync(string movieId)
        {
            var movie = await GetMovieDetails(movieId);
            if (movie == null)
            {
                return PRICE_NOT_AVAILABLE;
            }
            return movie.Price;
        }
        public async Task<MovieDetails> GetMovieDetails(string id)
        {
            var response = await CallExtAPI(apiUrl + "movie/" + id, accessToken);

            MovieDetails movie;
            ObjectCache cache = MemoryCache.Default;

            if (response == "")
            {
                /* error handle */
                string moviesCached = cache["cinemaWorldMovies_" + id] as string;
                if (moviesCached != null)
                {
                    response = cache.Get("cinemaWorldMovies_" + id).ToString();
                }
            }
            else
            {
                string moviesCached = cache["cinemaWorldMovies_" + id] as string;
                if (moviesCached == null)
                {
                    cache.Set("cinemaWorldMovies_" + id, response, null);
                }
            }

            movie = JsonConvert.DeserializeObject<MovieDetails>(response);

            return movie;
        }
    }
}
