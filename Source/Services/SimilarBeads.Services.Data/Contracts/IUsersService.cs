namespace SimilarBeads.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using SimilarBeads.Data.Models;

    public interface IUsersService
    {
        int GetCount();

        int GetArtistsCount();

        IQueryable<User> ByUsername(string username);

        IEnumerable<string> SearchByUsername(string username);

        void UpdateUser(User users);

        string UserIdByUsername(string username);

        bool UserIsArtist(string username);

        bool UserIsAdmin(string username);

        IQueryable<User> GetTopArtists(int numberOfArtists);

        IQueryable<User> GetArtistsCharts(string orderBy, string contains);
    }
}
