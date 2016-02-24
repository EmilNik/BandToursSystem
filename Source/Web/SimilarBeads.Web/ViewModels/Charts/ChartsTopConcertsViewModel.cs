namespace SimilarBeads.Web.ViewModels.Charts
{
    using Concert;
    using PagedList;

    public class ChartsTopConcertsViewModel : ChartsBaseViewModel
    {
        public IPagedList<ConcertViewModel> Concerts { get; set; }
    }
}
