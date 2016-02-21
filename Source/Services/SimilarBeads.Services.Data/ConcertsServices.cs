namespace SimilarBeads.Services.Data
{
    using System.Linq;

    using SimilarBeads.Data.Common;
    using SimilarBeads.Data.Models;

    public class ConcertsServices : IConcertsServices
    {
        private IRepository<Concert> concerts;

        public ConcertsServices(IRepository<Concert> concerts)
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
