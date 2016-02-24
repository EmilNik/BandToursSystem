namespace SimilarBeads.Data.Migrations
{
    using System;
    using System.Collections.Generic;
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
            var artists = new List<User>();

            if (!context.Users.Any())
            {
                var hasher = new PasswordHasher();
                var hashedPass = hasher.HashPassword("asdasd");

                for (int i = 0; i < 150; i++)
                {
                    var user = new User()
                    {
                        UserName = $"user{i}@site.com",
                        PasswordHash = hashedPass,
                        SecurityStamp = hashedPass,
                        Name = $"user{i}"
                    };

                    context.Users.Add(user);
                }

                for (int i = 0; i < 75; i++)
                {
                    var artist = new User()
                    {
                        UserName = $"artist{i}@site.com",
                        PasswordHash = hashedPass,
                        SecurityStamp = hashedPass,
                        IsArtist = true,
                        Name = $"artist{i}",
                        Subscribers = i * 2
                    };

                    artists.Add(artist);
                    context.Users.Add(artist);
                }

                context.SaveChanges();

                var blizzber = new User()
                {
                    Email = "emil.nik1002@gmail.com",
                    UserName = "emil.nik1002@gmail.com",
                    Name = "Blizzber",
                    IsAdmin = true,
                    IsArtist = true
                };

                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalRolesConstants.AdministratorRoleName };
                var artistRole = new IdentityRole { Name = GlobalRolesConstants.ArtistRoleName };
                roleManager.Create(role);
                roleManager.Create(artistRole);

                // Create admin user
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                userManager.Create(blizzber, "asdasd");

                // Assign user to admin role
                userManager.AddToRole(blizzber.Id, GlobalRolesConstants.AdministratorRoleName);
                userManager.AddToRole(blizzber.Id, GlobalRolesConstants.ArtistRoleName);
            }

            if (!context.Concerts.Any())
            {
                for (int i = 0; i < 50; i++)
                {
                    var concert = new Concert()
                    {
                        ArtistId = artists[(i + 1) % 10].Id,
                        City = "Sofia",
                        Date = DateTime.Now
                    };

                    context.Concerts.Add(concert);
                }

                context.SaveChanges();
            }

            if (!context.Songs.Any())
            {
                for (int i = 0; i < 1000; i++)
                {
                    var song = new Song()
                    {
                        Artist = artists[(i + 1) % 15],
                        Name = $"Songs {i}",
                        NumberOfPlays = ((i * 100) % 5000) + 1
                    };

                    context.Songs.Add(song);
                }

                context.SaveChanges();
            }
        }
    }
}
