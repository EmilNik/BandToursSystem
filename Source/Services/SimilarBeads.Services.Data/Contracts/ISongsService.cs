namespace SimilarBeads.Services.Data
{
    using System.Linq;

    using SimilarBeads.Data.Models;

    public interface ISongsService
    {
        int GetCount();

        IQueryable<Song> GetTopSongs(int numberOfSongs);

        IQueryable<Song> GetSongsCharts(string orderBy, string contains = "");

        Song Add(Song song);

        Song GetById(int id);

        Song UpdateSong(Song song);
    }
}
