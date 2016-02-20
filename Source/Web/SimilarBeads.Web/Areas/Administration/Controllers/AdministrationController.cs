namespace SimilarBeads.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using SimilarBeads.Common;
    using SimilarBeads.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
