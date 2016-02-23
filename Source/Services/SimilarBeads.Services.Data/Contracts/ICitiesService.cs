namespace SimilarBeads.Services.Data
{
    using System.Collections.Generic;
    using SimilarBeads.Data.Models;

    public interface ICitiesService
    {
        City CityByUsername(string cityName);

        ICollection<City> GetAll();
    }
}
