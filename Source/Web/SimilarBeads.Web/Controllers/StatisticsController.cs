namespace SimilarBeads.Web.Controllers
{
    using System.Web.Mvc;

    public class StatisticsController : BaseController
    {
        public ActionResult GetStatistics()
        {
            var statistics = new { };
            return this.Json(new { Statistics = statistics });
        }
    }
}