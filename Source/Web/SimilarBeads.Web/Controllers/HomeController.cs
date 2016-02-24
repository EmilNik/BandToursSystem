namespace SimilarBeads.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Artist;
    using ViewModels.Home;
    using ViewModels.Song;

    public class HomeController : BaseController
    {
        private IUsersService users;
        private ISongsService songs;

        public HomeController(IUsersService users, ISongsService songs)
        {
            this.users = users;
            this.songs = songs;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.GetTopArtistsAndSongs();
            return this.View(model);
        }

        [HttpGet]
        [OutputCache(Duration = 24 * 60 * 60)]
        private HomeViewModel GetTopArtistsAndSongs()
        {
            var artists = this.users.GetTopArtists(GlobalConstants.NumberOfArtistsOnHomePage).To<ArtistViewModel>().ToList();
            var songs = this.songs.GetTopSongs(GlobalConstants.NumberOfSongsOnHomePage).To<SongViewModel>().ToList();

            return new HomeViewModel()
            {
                Artists = artists,
                Songs = songs
            };
        }
    }
}
