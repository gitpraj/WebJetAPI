using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MovieSummary
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Poster { get; set; }
        public decimal? Price { get; set; }
        public string Provider { get; set; }

    }
}
