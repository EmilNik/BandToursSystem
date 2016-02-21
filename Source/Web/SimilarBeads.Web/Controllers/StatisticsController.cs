namespace SimilarBeads.Web.Controllers
{
    using System.Web.Mvc;

    using Services.Data;

    public class StatisticsController : BaseController
    {
        private IUsersService users;
        private ISongsService songs;
        private IConcertsService concerts;

        public StatisticsController(IUsersService users, ISongsService songs, IConcertsService concerts)
        {
            this.users = users;
            this.songs = songs;
            this.concerts = concerts;
        }

        [HttpGet]
        [OutputCache(Duration = 24 * 60 * 60)]
        public ActionResult GetStatistics()
        {
            var usersCount = this.users.GetCount();
            var songsCount = this.songs.GetCount();
            var concertsCount = this.concerts.GetCount();

            var statistics = new
            {
                users = usersCount,
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
    }
}
