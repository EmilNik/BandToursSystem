namespace SimilarBeads.Services.Data
{
    using System.Linq;

    using SimilarBeads.Data.Common;
    using SimilarBeads.Data.Models;

    public class SongsServices : ISongsServices
    {
        private IRepository<Song> songs;

        public SongsServices(IRepository<Song> songs)
        {
            this.songs = songs;
        }

        public int GetCount()
        {
            var count = this.songs.All().Count();
            return count;
        }
    }
}
