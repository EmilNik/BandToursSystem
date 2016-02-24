namespace SimilarBeads.Web.Areas.Admin.Views.Users
{
    using System.Linq;
    using System.Web.Mvc;

    using Controllers.BaseAdminController;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Users;
    using Services.Data;

    public class UsersListController : BaseAdminController
    {
        private IUsersService users;

        public UsersListController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.users.GetAll().To<UserViewModel>();

            return this.Json(result.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, UserInputModel user)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.users.GetById(user.Id).FirstOrDefault();
                entity.Name = user.Name;

                this.users.UpdateUser(entity);

                var result = this.users.GetById(user.Id).To<UserViewModel>().FirstOrDefault();
                return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, UserInputModel user)
        {
            var entity = this.users.GetById(user.Id).FirstOrDefault();

            if (entity == null)
            {
                return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
            }

            this.users.Delete(entity);
            var result = this.users.GetById(user.Id).To<UserViewModel>().FirstOrDefault();
            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
