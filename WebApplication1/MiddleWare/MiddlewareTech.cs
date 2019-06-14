using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ExternalAPI;

namespace WebApplication1.MiddleWare
{
    public class MiddleWareTech
    {
        public virtual Provider Provider { get; set; }
        public virtual async Task<IEnumerable<MovieSummary>> MovieSearchAsync(string searchTerm) { throw new NotImplementedException(); }
        public virtual async Task<decimal> GetMoviePriceAsync(string movieId) { throw new NotImplementedException(); }
    }
}
