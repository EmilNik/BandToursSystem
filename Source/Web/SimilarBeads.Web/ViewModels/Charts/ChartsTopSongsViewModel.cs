namespace SimilarBeads.Web.ViewModels.Charts
{
    using PagedList;
    using Song;

    public class ChartsTopSongsViewModel : ChartsBaseViewModel
    {
        public IPagedList<SongViewModel> Songs { get; set; }
    }
}
