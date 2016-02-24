namespace SimilarBeads.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using PagedList;
    using Services.Data;
    using ViewModels.Charts;
    using ViewModels.Concert;

    public class ConcertsController : BaseController
    {
        private IConcertsService concerts;
        private IUsersService users;

        public ConcertsController(IConcertsService concerts, IUsersService users)
        {
            this.concerts = concerts;
            this.users = users;
        }

        [HttpGet]
        public ActionResult TopConcerts(string sortOrder, string currentFilter, string currentCity = "", string searchString = "", int page = 1)
        {
            this.ViewBag.CurrentSort = sortOrder;
            this.ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            this.ViewBag.ArtistSortParam = sortOrder == "ArtistId" ? "ArtistId desc" : "ArtistId";
            this.ViewBag.CitySortParam = sortOrder == "CityId" ? "CityId desc" : "CityId";

            this.ViewBag.CurrentCity = currentCity;

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
                sortOrder = "Date desc";
            }

            if (searchString == null)
            {
                searchString = string.Empty;
            }

            var songs = this.concerts
                .GetConcertsCharts(sortOrder, searchString, currentCity)
                .To<ConcertViewModel>()
                .ToList();

            this.ViewBag.CurrentFilter = searchString;

            int pageSize = 10;
            var totalPages = songs.Count / pageSize;

            if (totalPages % 10 != 0)
            {
                totalPages += 1;
            }

            var model = new ChartsTopConcertsViewModel()
            {
                Concerts = songs.ToPagedList(page, pageSize),
                CurrentPage = page,
                TotalPages = totalPages
            };

            return this.View(model);
        }
    }
}
