namespace SimilarBeads.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using SimilarBeads.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetById(string id);

        int GetCount();

        int GetArtistsCount();

        IQueryable<User> ByUsername(string username);

        IQueryable<User> GetAll();

        IEnumerable<string> SearchByUsername(string username);

        void UpdateUser(User user);

        void Delete(User user);

        string UserIdByUsername(string username);

        bool UserIsArtist(string username);

        bool UserIsAdmin(string username);

        IQueryable<User> GetTopArtists(int numberOfArtists);

        IQueryable<User> GetArtistsCharts(string orderBy, string contains);
    }
}
