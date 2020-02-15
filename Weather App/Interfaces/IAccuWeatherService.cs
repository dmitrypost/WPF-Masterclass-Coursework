using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Interfaces
{
    public interface IAccuWeatherService
    {
        Task<IList<City>> GetCitiesAutoComplete(string query);
        Task<CurrentConditions> GetCurrentConditions(string locationKey);
    }
}