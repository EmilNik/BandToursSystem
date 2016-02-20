namespace SimilarBeads.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalRolesConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
