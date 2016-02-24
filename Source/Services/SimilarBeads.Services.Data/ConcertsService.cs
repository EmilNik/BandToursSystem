namespace SimilarBeads.Services.Data
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic;

    using SimilarBeads.Data.Common;
    using SimilarBeads.Data.Models;

    public class ConcertsService : IConcertsService
    {
        private IRepository<Concert> concerts;

        public ConcertsService(IRepository<Concert> concerts)
        {
            this.concerts = concerts;
        }

        public void AddConcert(Concert concert)
        {
            this.concerts.Add(concert);
            this.concerts.SaveChanges();
        }

        public IQueryable<Concert> GetConcertsCharts(string sortOrder, string searchString, string currentCity)
        {
            return this.concerts.All()
                .Where(c => c.City.Contains(currentCity))
                .Where(c => c.Artist.Name.Contains(searchString))
                .OrderBy(sortOrder);
        }

        public int GetCount()
        {
            var count = this.concerts.All().Count();
            return count;
        }

        public IQueryable<Concert> GetAll()
        {
            return this.concerts.All();
        }

        public IQueryable<Concert> GetById(int id)
        {
            return this.concerts.All()
                .Where(x => x.Id == id);
        }

        public void UpdateConcert(Concert concert)
        {
            this.concerts.Update(concert);
            this.concerts.SaveChanges();
        }

        public void Delete(Concert concert)
        {
            this.concerts.Delete(concert);
            this.concerts.SaveChanges();
        }
    }
}
