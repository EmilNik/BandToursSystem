namespace SimilarBeads.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;

    using SimilarBeads.Data.Common;
    using SimilarBeads.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public string UserIdByUsername(string username)
        {
            return this.users
                .All()
                .Where(u => u.Email == username)
                .Select(u => u.Id)
                .FirstOrDefault();
        }

        public bool UserIsArtist(string username)
        {
            return this.users
                .All()
                .Where(u => u.Email == username)
                .Select(u => u.IsArtist)
                .FirstOrDefault();
        }

        public bool UserIsAdmin(string username)
        {
            return this.users
                .All()
                .Where(u => u.Email == username)
                .Select(u => u.IsAdmin)
                .FirstOrDefault();
        }

        public IQueryable<User> ByUsername(string username)
        {
            return this.users
                .All()
                .Where(u => u.UserName == username);
        }

        public void UpdateUser(User user)
        {
            this.users.Update(user);
            this.users.SaveChanges();
        }

        public IEnumerable<string> SearchByUsername(string username)
        {
            return this.users
                .All()
                .Where(x => x.Name.Contains(username) || x.Email.Contains(username))
                .Select(u => u.Name)
                .AsEnumerable();
        }

        public int GetCount()
        {
            return this.users
                .All()
                .Count();
        }

        public int GetArtistsCount()
        {
            return this.users
                .All()
                .Where(x => x.IsArtist)
                .Count();
        }

        public IQueryable<User> GetTopArtists(int numbberOfArtists)
        {
            return this.users.All()
                .Where(x => x.IsArtist)
                .OrderByDescending(x => x.Subscribers)
                .Take(numbberOfArtists);
        }

        public IQueryable<User> GetArtistsCharts(string orderBy, string contains = "")
        {
            return this.users.All()
                .Where(x => x.IsArtist)
                .OrderBy(orderBy)
                .Where(x => x.Name.Contains(contains));
        }
    }
}
