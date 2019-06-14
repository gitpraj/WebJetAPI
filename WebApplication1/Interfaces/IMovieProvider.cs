using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IMovieProvider
    {
        Task<IEnumerable<MovieSummary>> FindMovies(string searchTerm);
        Task<decimal> MoviePrice(Provider provider, string movieId);
    }
}
