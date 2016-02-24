namespace SimilarBeads.Web.Areas.Admin.Views
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Controllers.BaseAdminController;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Concerts;
    using Services.Data;

    public class ConcertsListController : BaseAdminController
    {
        private IConcertsService concerts;

        public ConcertsListController(IConcertsService concerts)
        {
            this.concerts = concerts;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Concerts_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.concerts.GetAll().To<ConcertViewModel>();

            return this.Json(result.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Concerts_Update([DataSourceRequest]DataSourceRequest request, ConcertInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.concerts.GetById(model.Id).FirstOrDefault();
                //entity.Date = model.Date;
                entity.City = model.City;
                this.concerts.UpdateConcert(entity);

                var result = this.concerts.GetById(model.Id).To<ConcertViewModel>().FirstOrDefault();
                return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Concerts_Destroy([DataSourceRequest]DataSourceRequest request, ConcertInputModel model)
        {
            var entity = this.concerts.GetById(model.Id).FirstOrDefault();

            if (entity == null)
            {
                return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
            }

            this.concerts.Delete(entity);
            var result = this.concerts.GetById(model.Id).To<ConcertViewModel>().FirstOrDefault();

            return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
