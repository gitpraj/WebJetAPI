using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ExternalAPI;

namespace WebApplication1.MiddleWare
{
    /* MiddleWareTech class - functions which can be overridden and used - for any kind of providers */
    public class MiddleWareTech
    {
        public const int PRICE_NOT_AVAILABLE = -1;
        public virtual Provider Provider { get; set; }
        public virtual async Task<IEnumerable<MovieSummary>> MovieSearchAsync(string searchTerm) { throw new NotImplementedException(); }
        public virtual async Task<decimal> GetMoviePriceAsync(string movieId) { throw new NotImplementedException(); }
    }
}
