namespace SimilarBeads.Web.Controllers.BaseControllers
{
    using System.Web.Mvc;

    public class SearchController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
