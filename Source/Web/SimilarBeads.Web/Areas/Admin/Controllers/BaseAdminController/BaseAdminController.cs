namespace SimilarBeads.Web.Areas.Admin.Controllers.BaseAdminController
{
    using System.Web.Mvc;
    using Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalRolesConstants.AdministratorRoleName)]
    public class BaseAdminController : BaseController
    {
    }
}
