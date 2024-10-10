using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EarthquakesService : IEarthquakesService
    {
        private readonly string url = "http://www.koeri.boun.edu.tr/scripts/sondepremler.asp";

        private string[] GetData()
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var pre = doc.DocumentNode.SelectSingleNode("//pre");
            string text = pre.InnerText;
            string[] lines = text.Split("\n");
            return lines.Skip(7).Take(500).ToArray();
        }

        public async Task<EarthquakeDetail> GetEarthquake(DateTime datetime)
        {
            var item = new EarthquakeDetail();
            var lines = GetData();
            foreach (var line in lines)
            {
                string[] cols = Regex.Split(line, @"\s{2,}");
                if (DateTime.Parse(cols[0]) == datetime)
                {
                    item = new EarthquakeDetail
                    {
                        DateTime = DateTime.Parse(cols[0]),
                        Location = cols[7],
                        ML = double.Parse(cols[5], CultureInfo.InvariantCulture),
                        Depth = double.Parse(cols[3], CultureInfo.InvariantCulture),
                        Latitude = double.Parse(cols[1], CultureInfo.InvariantCulture),
                        Longitude = double.Parse(cols[2], CultureInfo.InvariantCulture),
                        MD = double.Parse(cols[4].Replace("-.-", "0.0"), CultureInfo.InvariantCulture),
                        Mw = double.Parse(cols[6].Replace("-.-", "0.0"), CultureInfo.InvariantCulture),
                        SolutionQuality = cols[8]
                    };

                }
            }
            return await Task.Run(() => item);
        }

        public async Task<IEnumerable<EarthquakeListItem>> GetEarthquakes()
        {
            var lines = GetData();
            var items = new List<EarthquakeListItem>();

            foreach (var line in lines)
            {
                string[] cols = Regex.Split(line, @"\s{2,}");
                var item = new EarthquakeListItem
                {
                    DateTime = DateTime.Parse(cols[0]),
                    Location = cols[7],
                    ML = double.Parse(cols[5], CultureInfo.InvariantCulture)
                };
                items.Add(item);
            }

            return await Task.Run(() => items);
        }
    }
}
