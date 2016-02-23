namespace SimilarBeads.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;

    public class StatisticsController : BaseController
    {
        private IUsersService users;
        private ISongsService songs;
        private IConcertsService concerts;
        private ICitiesService cities;

        public StatisticsController(IUsersService users, ISongsService songs, IConcertsService concerts, ICitiesService cities)
        {
            this.users = users;
            this.songs = songs;
            this.concerts = concerts;
            this.cities = cities;
        }

        [HttpGet]
        [OutputCache(Duration = 24 * 60 * 60)]
        public ActionResult GetStatistics()
        {
            var usersCount = this.users.GetCount();
            var artistCount = this.users.GetArtistsCount();
            var songsCount = this.songs.GetCount();
            var concertsCount = this.concerts.GetCount();

            var statistics = new
            {
                users = usersCount,
                artists = artistCount,
                songs = songsCount,
                concerts = concertsCount
            };

            return this.Json(new { Statistics = statistics }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Charts()
        {
            return this.View();
        }

        [HttpGet]
        public void Cities()
        {
            this.TempData["Cities"] = this.GetCities();
            this.RedirectToAction("Cities", "Autocomplete");
        }

        [OutputCache(Duration = 24 * 60 * 60)]
        private ICollection<City> GetCities()
        {
            return this.cities.GetAll();
        }
    }
}
