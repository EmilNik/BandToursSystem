namespace SimilarBeads.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public ICollection<SongViewModel> Songs { get; set; }

        public ICollection<ArtistViewModel> Artists { get; set; }
    }
}