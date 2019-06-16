using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ExternalAPI;

namespace WebApplication1.MiddleWare
{
    /* Intermediary class is literally like an intermediary between the API controller and the external controller.
     * Member: CinemaWorld Provider 
               FilmWorld Provider
               allProviders - List of all the providers of type MiddleWareTech class*/
    public class Intermediary : IMovieProvider
    {
        CinemaWorld CinemaWorldProv;
        FilmWorld filmWorldProv;
        List<MiddleWareTech> allProviders;

        public Intermediary(CinemaWorld cinemaWorld, FilmWorld filmWorld)
        {
            CinemaWorldProv = cinemaWorld;
            filmWorldProv = filmWorld;

            allProviders = new List<MiddleWareTech> { CinemaWorldProv, filmWorldProv };
        }

        /* FindMovies() : parallel async calls (both the providers) to MovieSearchAsync  */
        public async Task<IEnumerable<MovieSummary>> FindMovies(string searchTerm)
        {
            List<MovieSummary> allMovies = new List<MovieSummary>();
            List<string> errorMessages = new List<string>();
            List<Task> tasks = new List<Task>();

            foreach (MiddleWareTech api in allProviders)
            {
                tasks.Add(
                    Task.Run(async () => {
                        try
                        {
                            IEnumerable<MovieSummary> movies = await api.MovieSearchAsync(searchTerm);
                            allMovies.AddRange(movies);
                        }
                        catch (Exception e) 
                        {
                            errorMessages.Add("Error from " + api);
                        }
                    }));
            }

            await Task.WhenAll(tasks);
            return allMovies;
        }

        /* MoviePrice() : async call (Provider which calls) to GetMoviePriceAsync  */
        public async Task<decimal> MoviePrice(Provider provider, string movieId)
        {
            var client = allProviders.SingleOrDefault(x => x.Provider == provider);
            var price = await client.GetMoviePriceAsync(movieId);
            return price;
        }
    }

    
}
