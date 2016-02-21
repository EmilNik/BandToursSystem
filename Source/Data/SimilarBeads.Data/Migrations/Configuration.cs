namespace SimilarBeads.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    using SimilarBeads.Common.Constants;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //var administratorUserName = DatabaseSeedConstants.AdministratorUserName;
            //var administratorPassword = DatabaseSeedConstants.AdministratorPassword;

            //var artistUserName = DatabaseSeedConstants.ArtistUserName;
            //var artistPassword = DatabaseSeedConstants.ArtistPassword;

            //var userUserName = DatabaseSeedConstants.UserUserName;
            //var userPassword = DatabaseSeedConstants.UserPassword;

            //if (!context.Roles.Any())
            //{
            //    // Create role
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    var adminRole = new IdentityRole { Name = GlobalRolesConstants.AdministratorRoleName };
            //    var artistRole = new IdentityRole { Name = GlobalRolesConstants.ArtistRoleName };
            //    var userRole = new IdentityRole { Name = GlobalRolesConstants.UserRoleName };
            //    roleManager.Create(adminRole);
            //    roleManager.Create(artistRole);
            //    roleManager.Create(userRole);

            //    // Create user
            //    var userStore = new UserStore<ApplicationUser>(context);
            //    var userManager = new UserManager<ApplicationUser>(userStore);
            //    var admin = new ApplicationUser { UserName = administratorUserName, Email = administratorUserName };
            //    userManager.Create(admin, artistPassword);

            //    var artist = new ApplicationUser { UserName = artistUserName, Email = artistUserName };
            //    userManager.Create(artist, administratorPassword);

            //    var user = new ApplicationUser { UserName = userUserName, Email = userUserName };
            //    userManager.Create(user, userPassword);

            //    // Assign user to role
            //    userManager.AddToRole(admin.Id, GlobalRolesConstants.AdministratorRoleName);
            //    userManager.AddToRole(artist.Id, GlobalRolesConstants.ArtistRoleName);
            //    userManager.AddToRole(user.Id, GlobalRolesConstants.UserRoleName);
            //}
        }
    }
}
