namespace SimilarBeads.Web.ViewModels.Charts
{
    using Artist;
    using PagedList;

    public class ChartsTopArtistsViewModel : ChartsBaseViewModel
    {
        public IPagedList<ArtistViewModel> Artists { get; set; }
    }
}
