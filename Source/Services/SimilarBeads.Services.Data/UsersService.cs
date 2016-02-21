namespace SimilarBeads.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

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
                .Where(u => u.Name == username)
                .Select(u => u.Id)
                .FirstOrDefault();
        }

        public bool UserIsArtist(string username)
        {
            return this.users
                .All()
                .Where(u => u.Name == username)
                .Select(u => u.IsArtist)
                .FirstOrDefault();
        }

        public bool UserIsAdmin(string username)
        {
            return this.users
                .All()
                .Where(u => u.Name == username)
                .Select(u => u.IsAdmin)
                .FirstOrDefault();
        }

        public IQueryable<User> ByUsername(string username)
        {
            return this.users
                .All()
                .Where(u => u.Name == username);
        }

        public IEnumerable<string> SearchByUsername(string username)
        {
            return this.users
                .All()
                .Where(x => x.Name.Contains(username))
                .Select(u => u.Name)
                .AsEnumerable();
        }

        public int GetCount()
        {
            return this.users
                .All()
                .Count();
        }
    }
}
