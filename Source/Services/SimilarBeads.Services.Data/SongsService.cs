﻿namespace SimilarBeads.Services.Data
{
    using System.Linq;
    using System.Linq.Dynamic;

    using SimilarBeads.Data.Common;
    using SimilarBeads.Data.Models;

    public class SongsService : ISongsService
    {
        private IRepository<Song> songs;

        public SongsService(IRepository<Song> songs)
        {
            this.songs = songs;
        }

        public int GetCount()
        {
            var count = this.songs.All().Count();
            return count;
        }

        public IQueryable<Song> GetTopSongs(int numberOfSongs)
        {
            return this.songs
                .All()
                .OrderByDescending(x => x.NumberOfPlays)
                .Take(numberOfSongs);
        }

        public IQueryable<Song> GetSongsCharts(int numberOfSongs, string orderBy, int numberToSkip)
        {
            return this.songs.All()
                .OrderBy(orderBy)
                .Skip(numberToSkip)
                .Take(numberOfSongs);
        }
    }
}