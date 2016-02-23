namespace SimilarBeads.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using PagedList;
    using Services.Data;
    using ViewModels.Artist;
    using ViewModels.Charts;
    using ViewModels.Song;
    public class ChartsController : BaseController
    {
        private IUsersService users;
        private ISongsService songs;

        public ChartsController(IUsersService users, ISongsService songs)
        {
            this.users = users;
            this.songs = songs;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult TopArtists(string sortOrder, string currentFilter, string searchString = "", int page = 1)
        {
            this.ViewBag.CurrentSort = sortOrder;
            this.ViewBag.NameSortParm = sortOrder == "Name" ? "Name desc" : "Name";
            this.ViewBag.SongsPlaysSortParam = sortOrder == "SongsPlays" ? "SongsPlays desc" : "SongsPlays";
            this.ViewBag.SubscribersSortParam = sortOrder == "Subscribers" ? "Subscribers desc" : "Subscribers";

            if (searchString != string.Empty)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (sortOrder == null || sortOrder == string.Empty)
            {
                sortOrder = "Subscribers desc";
            }

            if (searchString == null)
            {
                searchString = string.Empty;
            }

            var artists = this.users
                .GetArtistsCharts(sortOrder, searchString)
                .To<ArtistViewModel>()
                .ToList();

            this.ViewBag.CurrentFilter = searchString;

            int pageSize = 10;
            var totalPages = artists.Count / pageSize;

            if (totalPages % 10 != 0)
            {
                totalPages += 1;
            }

            var model = new ChartsTopArtistsViewModel()
            {
                Artists = artists.ToPagedList(page, pageSize),
                CurrentPage = page,
                TotalPages = totalPages
            };

            return this.View(model);
        }

        [HttpGet]
        public ActionResult TopSongs(string sortOrder, string currentFilter, string searchString = "", int page = 1)
        {
            this.ViewBag.CurrentSort = sortOrder;
            this.ViewBag.NameSortParm = sortOrder == "Name" ? "Name desc" : "Name";
            this.ViewBag.SongsPlaysSortParam = sortOrder == "ArtistId" ? "ArtistId desc" : "ArtistId";
            this.ViewBag.SubscribersSortParam = sortOrder == "NumberOfPlays" ? "NumberOfPlays desc" : "NumberOfPlays";

            if (searchString != string.Empty)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (sortOrder == null || sortOrder == string.Empty)
            {
                sortOrder = "NumberOfPlays desc";
            }

            if (searchString == null)
            {
                searchString = string.Empty;
            }

            var songs = this.songs
                .GetSongsCharts(sortOrder, searchString)
                .To<SongViewModel>()
                .ToList();

            this.ViewBag.CurrentFilter = searchString;

            int pageSize = 10;
            var totalPages = songs.Count / pageSize;

            if (totalPages % 10 != 0)
            {
                totalPages += 1;
            }

            var model = new ChartsTopSongsViewModel()
            {
                Songs = songs.ToPagedList(page, pageSize),
                CurrentPage = page,
                TotalPages = totalPages
            };

            return this.View(model);
        }
    }
}
