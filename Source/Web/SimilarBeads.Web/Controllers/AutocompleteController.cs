namespace SimilarBeads.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;

    public class AutocompleteController : BaseController
    {
        public ActionResult Cities(string term)
        {
            var cities = (List<City>)this.TempData["Cities"];
            var filteredItems = cities.Where(item => item.Name.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0);
            return this.Json(filteredItems, JsonRequestBehavior.AllowGet);
        }
    }
}
