namespace SimilarBeads.Services.Data
{
    using System.Linq;

    using SimilarBeads.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
