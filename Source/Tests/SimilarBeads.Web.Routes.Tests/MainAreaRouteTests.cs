namespace SimilarBeads.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class MainAreaRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.routeCollection = RouteTable.Routes;
        }

        [TestFixtureTearDown]
        public void RouteCollectionDestroy()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public void TestDefaultRoute()
        {
            var url = "/";
            this.routeCollection.ShouldMap(url).To<HomeController>(c => c.Index());
        }

        [Test]
        public void TestDefaultRouteAgain()
        {
            var url = "/Home/Index";
            this.routeCollection.ShouldMap(url).To<HomeController>(c => c.Index());
        }

        [Test]
        public void TestChartsRouteTopArtists()
        {
            var url = "/Charts/TopArtists";
            this.routeCollection.ShouldMap(url).To<ChartsController>(c => c.TopArtists(string.Empty, string.Empty, string.Empty, 1));
        }

        [Test]
        public void TestChartsRouteTopSongs()
        {
            var url = "/Charts/TopSongs";
            this.routeCollection.ShouldMap(url).To<ChartsController>(c => c.TopSongs(string.Empty, string.Empty, string.Empty, 1));
        }

        [Test]
        public void TestConcertsTopConcers()
        {
            var url = "/Concerts/TopConcerts";
            this.routeCollection.ShouldMap(url).To<ConcertsController>(c => c.TopConcerts(string.Empty, string.Empty, string.Empty, string.Empty, 1));
        }

        [Test]
        public void TestDetailsDetails()
        {
            var url = "/Details/Details";
            this.routeCollection.ShouldMap(url).To<DetailsController>(c => c.Details(string.Empty));
        }

        [Test]
        public void TestDetailsSubscribe()
        {
            var url = "/Details/Subscribe";
            this.routeCollection.ShouldMap(url).To<DetailsController>(c => c.Subscribe(string.Empty));
        }

        [Test]
        public void TestDetailsPlaySong()
        {
            var url = "/Details/PlaySong";
            this.routeCollection.ShouldMap(url).To<DetailsController>(c => c.PlaySong(1));
        }

        [Test]
        public void TestErrorHttpError()
        {
            var url = "/Error/HttpError";
            this.routeCollection.ShouldMap(url).To<ErrorController>(c => c.HttpError(string.Empty));
        }

        [Test]
        public void TestManageUser()
        {
            var url = "/ManageUser";
            this.routeCollection.ShouldMap(url).To<ManageUserController>(c => c.Index(new ViewModels.User.UserViewModel(), string.Empty));
        }

        [Test]
        public void TestManageUserUpdate()
        {
            var url = "/ManageUser/Update";
            this.routeCollection.ShouldMap(url).To<ManageUserController>(c => c.Update(new ViewModels.Manage.IndexViewModel()));
        }

        [Test]
        public void TestRegisterRegister()
        {
            var url = "/Account/Register";
            this.routeCollection.ShouldMap(url).To<RegisterController>(c => c.Register());
        }

        [Test]
        public void TestSearchSearch()
        {
            var url = "/Search";
            this.routeCollection.ShouldMap(url).To<SearchController>(c => c.Index());
        }

        [Test]
        public void TestStatisticsGetStatistics()
        {
            var url = "/Statistics/GetStatistics";
            this.routeCollection.ShouldMap(url).To<StatisticsController>(c => c.GetStatistics());
        }

        [Test]
        public void TestStatisticsCharts()
        {
            var url = "/Statistics/Charts";
            this.routeCollection.ShouldMap(url).To<StatisticsController>(c => c.Charts());
        }
    }
}
