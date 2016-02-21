namespace SimilarBeads.Web.Controllers
{
    using System.Linq;

    using Data.Models;
    using Services.Data;

    public class BaseAuthorizationController : BaseController
    {
        public BaseAuthorizationController(IUsersService usersService)
        {
            this.UsersService = usersService;
            this.SetCurrentUser();
        }

        protected IUsersService UsersService { get; private set; }

        protected User CurrentUser { get; private set; }

        private void SetCurrentUser()
        {
            var username = this.User.Identity.Name;
            if (username != null)
            {
                this.CurrentUser = this.UsersService
                    .ByUsername(username)
                    .FirstOrDefault();
            }
        }
    }
}
