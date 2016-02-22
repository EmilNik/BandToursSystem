namespace SimilarBeads.Web.Controllers
{
    using Services.Data;
    using System.Web.Mvc;

    public class HomeController : BaseAuthorizationController
    {
        public HomeController(IUsersService users)
            : base(users)
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
