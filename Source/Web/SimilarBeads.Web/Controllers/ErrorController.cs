namespace SimilarBeads.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : BaseController
    {
        public ActionResult HttpError(string error)
        {
            this.ViewBag.Description = error;
            return this.View();
        }
    }
}
