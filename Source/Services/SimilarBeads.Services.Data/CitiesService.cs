namespace SimilarBeads.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SimilarBeads.Data.Common;
    using SimilarBeads.Data.Models;

    public class CitiesService : ICitiesService
    {
        private readonly IRepository<City> cities;

        public CitiesService(IRepository<City> cities)
        {
            this.cities = cities;
        }

        public City CityByUsername(string cityName)
        {
            return this.cities
                .All()
                .Where(u => u.Name == cityName)
                .FirstOrDefault();
        }

        public ICollection<City> GetAll()
        {
            return this.cities.All().ToList();
        }
    }
}
