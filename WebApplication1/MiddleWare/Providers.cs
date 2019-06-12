using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ExternalAPI;

namespace WebApplication1.MiddleWare
{
    public class Providers
    {
        public virtual async Task<IEnumerable<MovieSummary>> MovieSearch(string searchTerm) { throw new NotImplementedException(); }
        public virtual async Task<decimal> GetMoviePrice(string movieId) { throw new NotImplementedException(); }
    }
}
