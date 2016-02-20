namespace SimilarBeads.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = DatabaseSeedConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
