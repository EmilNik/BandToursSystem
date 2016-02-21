namespace SimilarBeads.Services.Data
{
    using System.Linq;

    using SimilarBeads.Data.Common;
    using SimilarBeads.Data.Models;

    public class ConcertsService : IConcertsService
    {
        private IRepository<Concert> concerts;

        public ConcertsService(IRepository<Concert> concerts)
        {
            this.concerts = concerts;
        }

        public int GetCount()
        {
            var count = this.concerts.All().Count();
            return count;
        }
    }
}
