﻿namespace SimilarBeads.Services.Data
{
    using System.Linq;

    using SimilarBeads.Data.Models;

    public interface ISongsService
    {
        int GetCount();

        IQueryable<Song> GetTopSongs(int numberOfSongs);

        IQueryable<Song> GetSongsCharts(int numberOfSongs, string orderBy, int numberToSkip);
    }
}
