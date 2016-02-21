namespace SimilarBeads.Web.Controllers
{
    using System.Web.Mvc;

    public class StaticContentController : BaseController
    {
        public ActionResult PageNotFound()
        {
            return this.View();
        }
    }
}
