using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class EarthquakeListItem
    {
        public DateTime DateTime { get; set; }
        public double? ML { get; set; }
        public string? Location { get; set; }
    }

    public class EarthquakeDetail
    {
        public DateTime DateTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Depth { get; set; }
        public double? MD { get; set; }
        public double? ML { get; set; }
        public double? Mw { get; set; }
        public string? Location { get; set; }
        public string? SolutionQuality { get; set; }
    }
}
