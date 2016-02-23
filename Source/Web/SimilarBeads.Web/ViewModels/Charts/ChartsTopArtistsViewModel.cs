namespace SimilarBeads.Web.ViewModels.Charts
{
    using Artist;
    using PagedList;

    public class ChartsTopArtistsViewModel
    {
        public IPagedList<ArtistViewModel> Artists { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
