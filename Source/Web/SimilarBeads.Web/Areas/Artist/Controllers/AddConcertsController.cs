namespace SimilarBeads.Web.Areas.Artist.Controllers
{
    using System.Web.Mvc;

    using Base;
    using Data.Models;
    using Infrastructure.IdentityExtensions;
    using Services.Data;
    using ViewModels.Concert;

    public class AddConcertsController : BaseArtistController
    {
        private IConcertsService concerts;
        private IUsersService users;

        public AddConcertsController(IConcertsService concerts, IUsersService users)
        {
            this.concerts = concerts;
            this.users = users;
        }

        [HttpGet]
        public ActionResult AddConcert()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddConcert(ConcertInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var artistId = this.users.UserIdByUsername(this.User.Identity.GetName());

            var concert = new Concert()
            {
                Date = model.Date,
                City = model.City,
                ArtistId = artistId
            };

            this.concerts.AddConcert(concert);

            this.TempData["Notification"] = "You added concert successfully!";
            return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }
    }
}
