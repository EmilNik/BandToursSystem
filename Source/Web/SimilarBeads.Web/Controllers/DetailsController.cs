namespace SimilarBeads.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.User;

    [Authorize]
    public class DetailsController : BaseController
    {
        private IUsersService users;
        private ISongsService songs;

        public DetailsController(IUsersService users, ISongsService songs)
        {
            this.users = users;
            this.songs = songs;
        }

        [HttpGet]
        public ActionResult Details(string username)
        {
            if (username == null)
            {
                return this.View();
            }

            var model = this.users.ByUsername(username).To<UserProfileViewModel>().FirstOrDefault();
            return this.View(model);
        }

        [HttpPost]
        public ActionResult Subscribe(string username)
        {
            var user = this.users.ByUsername(username).FirstOrDefault();
            user.Subscribers += 1;
            this.users.UpdateUser(user);
            var subscribers = user.Subscribers;

            return this.Json(new { Count = subscribers });
        }

        public ActionResult PlaySong(int id)
        {
            var song = this.songs.GetById(id);

            song.NumberOfPlays += 1;

            var newSong = this.songs.UpdateSong(song);

            return this.Json(new { Count = newSong.NumberOfPlays });
        }
    }
}
