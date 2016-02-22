namespace SimilarBeads.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
