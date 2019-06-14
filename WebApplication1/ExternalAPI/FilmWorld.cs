using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.ExternalAPI
{
    public class FilmWorld : APICall
    {
        public FilmWorld(string _apiUrl, string _accessToken)
        {
            apiUrl = _apiUrl;
            accessToken = _accessToken;
            Provider = Provider.FilmWorld;
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
                string moviesCached = cache["filmWorldMovies"] as string;
                if (moviesCached != null)
                {
                    response = cache.Get("filmWorldMovies").ToString();
                }
            }
            else
            {
                string moviesCached = cache["filmWorldMovies"] as string;
                if (moviesCached == null)
                {
                    cache.Set("filmWorldMovies", response, null);
                }
            }

            json = JObject.Parse(response);
            jsonArr = JArray.Parse(json["Movies"].ToString());
            moviesList = JsonConvert.DeserializeObject<List<MovieSummary>>(jsonArr.ToString());
            var movies = moviesList.Where(m => m.Title.ToLower().Contains(searchTerm.ToLower(), StringComparison.OrdinalIgnoreCase)).ToList(); // Filter by searchTerm
            movies.ForEach(m => { m.Provider = Provider.FilmWorld; });

            return movies;
        }

        public override async Task<decimal> GetMoviePriceAsync(string movieId)
        {
            var movie = await GetMovieDetailsAsync(movieId);
            if (movie == null)
            {
                return PRICE_NOT_AVAILABLE;
            }
            return movie.Price;
        }
        public async Task<MovieDetails> GetMovieDetailsAsync(string id)
        {
            var response = await CallExtAPI(apiUrl + "movie/" + id, accessToken);

            MovieDetails movie;
            ObjectCache cache = MemoryCache.Default;

            if (response == "")
            {
                /* error handle */
                string moviesCached = cache["filmWorldMovies_"+id] as string;
                if (moviesCached != null)
                {
                    response = cache.Get("filmWorldMovies_"+id).ToString();
                }
            }
            else
            {
                string moviesCached = cache["filmWorldMovies_" + id] as string;
                if (moviesCached == null)
                {
                    cache.Set("filmWorldMovies_" + id, response, null);
                }
            }

            movie = JsonConvert.DeserializeObject<MovieDetails>(response);

            return movie;
        }
    }
}
