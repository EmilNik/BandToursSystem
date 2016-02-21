namespace SimilarBeads.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using SimilarBeads.Data.Models;

    public interface IUsersService
    {
        int GetCount();

        IQueryable<User> ByUsername(string username);

        IEnumerable<string> SearchByUsername(string username);

        string UserIdByUsername(string username);

        bool UserIsArtist(string username);
    }
}
