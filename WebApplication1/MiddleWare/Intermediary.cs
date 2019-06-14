using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ExternalAPI;

namespace WebApplication1.MiddleWare
{
    public class Intermediary : IMovieProvider
    {
        CinemaWorld _cinemaWorldClient;
        FilmWorld _filmWorldClient;
        List<MiddleWareTech> _all;

        public Intermediary()
        {
        }

        public Intermediary(CinemaWorld cinemaWorld, FilmWorld filmWorld)
        {
            _cinemaWorldClient = cinemaWorld;
            _filmWorldClient = filmWorld;

            _all = new List<MiddleWareTech> { _cinemaWorldClient , _filmWorldClient };
        }


        public async Task<IEnumerable<MovieSummary>> FindMovies(string searchTerm)
        {
            List<MovieSummary> allMovies = new List<MovieSummary>();
            List<string> errorMessages = new List<string>();
            List<Task> tasks = new List<Task>();

            foreach (MiddleWareTech api in _all)
            {
                tasks.Add(Task.Run(async () => {
                    try
                    {
                        IEnumerable<MovieSummary> movies = await api.MovieSearchAsync(searchTerm);
                        allMovies.AddRange(movies);
                    }
                    catch (Exception e) 
                    {
                        // TODO: Log error
                        
                            errorMessages.Add("Error from " + api);
                        
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

        public async Task<decimal> MoviePrice(Provider provider, string movieId)
        {
            var client = _all.SingleOrDefault(x => x.Provider == provider);
            var price = await client.GetMoviePriceAsync(movieId);
            return price;
        }
    }

    
}
