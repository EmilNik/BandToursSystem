namespace SimilarBeads.Services.Data
{
    using System.Linq;
    using SimilarBeads.Data.Models;

    public interface IConcertsService
    {
        int GetCount();

        IQueryable<Concert> GetConcertsCharts(string sortOrder, string searchString, string currentCity);

        IQueryable<Concert> GetAll();

        IQueryable<Concert> GetById(int id);

        void UpdateConcert(Concert concert);

        void AddConcert(Concert concert);

        void Delete(Concert concert);
    }
}
