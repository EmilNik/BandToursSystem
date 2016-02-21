namespace SimilarBeads.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
