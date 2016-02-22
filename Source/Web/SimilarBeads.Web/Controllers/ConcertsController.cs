namespace SimilarBeads.Web.Controllers
{
    using System.Web.Mvc;

    public class ConcertsController : BaseController
    {
        public ConcertsController()
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
