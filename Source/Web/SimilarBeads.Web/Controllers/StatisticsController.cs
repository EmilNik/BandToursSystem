namespace SimilarBeads.Web.Controllers
{
    using System.Web.Mvc;

    using Services.Data;

    public class StatisticsController : BaseController
    {
        private IUsersServices users;
        private ISongsServices songs;
        private IConcertsServices concerts;

        public StatisticsController(IUsersServices users, ISongsServices songs, IConcertsServices concerts)
        {
            this.users = users;
            this.songs = songs;
            this.concerts = concerts;
        }

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

            return this.Json(new { Statistics = statistics });
        }
    }
}
