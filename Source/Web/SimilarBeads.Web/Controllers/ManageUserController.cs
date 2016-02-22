namespace SimilarBeads.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Data;
    using ViewModels.Manage;

    public class ManageUserController : BaseController
    {
        [HttpPost]
        public ActionResult Update(UserInputModel model)
        {
            return this.View();
        }
    }
}
