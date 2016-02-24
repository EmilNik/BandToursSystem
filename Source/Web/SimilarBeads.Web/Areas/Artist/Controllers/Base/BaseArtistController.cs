namespace SimilarBeads.Web.Areas.Artist.Controllers.Base
{
    using System.Web.Mvc;

    using Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalRolesConstants.AdministratorRoleName)]
    public class BaseArtistController : BaseController
    {
    }
}
