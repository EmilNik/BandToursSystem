namespace SimilarBeads.Web.Areas.Artist.Controllers
{
    using System.Web.Mvc;

    using Base;
    using Data.Models;
    using Infrastructure.IdentityExtensions;
    using Services.Data;
    using ViewModels.Song;

    public class ArtistsController : BaseArtistController
    {
        private IUsersService users;
        private ISongsService songs;

        public ArtistsController(IUsersService users, ISongsService songs)
        {
            this.users = users;
            this.songs = songs;
        }

        [HttpGet]
        public ActionResult AddSong()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddSong(SongInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var artistId = this.users.UserIdByUsername(this.User.Identity.GetName());
            var song = new Song()
            {
                Name = model.Name,
                ArtistId = artistId
            };

            var newSong = this.songs.Add(song);

            this.TempData["Notification"] = $"You added the song {newSong.Name} successfully!";
            return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }
    }
}
