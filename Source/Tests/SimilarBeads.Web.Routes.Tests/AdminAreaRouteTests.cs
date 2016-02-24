namespace SimilarBeads.Web.Routes.Tests
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using Areas.Admin;
    using Areas.Admin.Views;
    using Areas.Admin.Views.Users;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class AdminAreaRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            var area2Reg = new AdminAreaRegistration();
            var area2Context = new AreaRegistrationContext(area2Reg.AreaName, RouteTable.Routes);
            area2Reg.RegisterArea(area2Context);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.routeCollection = RouteTable.Routes;
        }

        [TestFixtureTearDown]
        public void RouteCollectionDestroy()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public void TestConcertsList()
        {
            var url = "/Admin/ConcertsList/Index";
            this.routeCollection.ShouldMap(url).To<ConcertsListController>(c => c.Index());
        }

        [Test]
        public void TestUsersList()
        {
            var url = "Admin/UsersList/Index";
            this.routeCollection.ShouldMap(url).To<UsersListController>(c => c.Index());
        }
    }
}
