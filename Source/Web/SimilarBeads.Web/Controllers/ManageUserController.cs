namespace SimilarBeads.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Data;
    using ViewModels.Manage;
    using ViewModels.User;

    public class ManageUserController : BaseController
    {
        private IUsersService users;
        private ICitiesService cities;

        public ManageUserController(IUsersService users, ICitiesService cities)
        {
            this.users = users;
            this.cities = cities;
        }

        [HttpPost]
        public ActionResult Index(UserViewModel model, string submitButton)
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Update(IndexViewModel model)
        {
            var user = model.User;
            var currentUser = this.users.ByUsername(this.User.Identity.Name).FirstOrDefault();

            if (currentUser == null)
            {
                return this.RedirectToAction("Index", "Manage", new { model = model });
            }

            currentUser.CityId = this.cities.CityByUsername(user.City).Id;
            currentUser.Name = user.Name;
            this.users.UpdateUser(currentUser);
            return this.RedirectToAction("Index", "Manage", new { model = model });
        }
    }
}
