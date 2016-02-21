namespace SimilarBeads.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Data;

    public class ConcertsController : BaseAuthorizationController
    {
        public ConcertsController(IUsersService users)
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
