namespace SimilarBeads.Web.Areas.Artist
{
    using System.Web.Mvc;

    public class ArtistAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Artist";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Artist_default",
                "Artist/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
