namespace SimilarBeads.Services.Data
{
    using System.Linq;

    using SimilarBeads.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}
