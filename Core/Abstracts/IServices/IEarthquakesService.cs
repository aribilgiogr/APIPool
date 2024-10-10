using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IEarthquakesService
    {
        Task<IEnumerable<EarthquakeListItem>> GetEarthquakes();
        Task<EarthquakeDetail> GetEarthquake(DateTime datetime);
    }
}
