using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ExternalAPI;

namespace WebApplication1.MiddleWare
{
    public class Intermediary : MovieProvider
    {
        CinemaWorld _cinemaWorldClient;
        FilmWorld _filmWorldClient;
        List<Providers> _all;

        public Intermediary()
        {
        }

        public Intermediary(CinemaWorld cinemaWorld, FilmWorld filmWorld)
        {
            _cinemaWorldClient = cinemaWorld;
            _filmWorldClient = filmWorld;

            _all = new List<Providers> { _cinemaWorldClient , _filmWorldClient };
        }


        public async Task<IEnumerable<MovieSummary>> FindMovies(string searchTerm)
        {
            //var apiClients = providers == null ? _allClients : _allClients.Where(c => providers.Contains(c.Provider));
            //Providers apis = new Providers(_cinemaWorldClient, _filmWorldClient);
            //_all.Add(apis);

            List<MovieSummary> allMovies = new List<MovieSummary>();
            List<string> errorMessages = new List<string>();
            List<Task> tasks = new List<Task>();

            foreach (Providers api in _all)
            {
                tasks.Add(Task.Run(async () => {
                    try
                    {
                        IEnumerable<MovieSummary> movies = await api.MovieSearch(searchTerm);
                        allMovies.AddRange(movies);
                    }
                    catch
                    {
                        // TODO: Log error
                        errorMessages.Add("Error getting result from " + api);
                    }
                }));
            }

            await Task.WhenAll(tasks);

            // TODO: Set result relevance so it can be ordered by relevance on the frontend if needed

            //FindMoviesResult result = new FindMoviesResult
            //{
            //    Movies = allMovies,
            //    ErrorMessages = errorMessages
            //};

            return allMovies;
        }

        public async Task<decimal> MoviePrice(MovieProvider provider, string movieId)
        {
            //var client = _allClients.SingleOrDefault(x => x.Provider == provider);
            //var price = await client.GetPriceAsync(movieId);
            //return price;
            return 0;
        }
    }

    
}
