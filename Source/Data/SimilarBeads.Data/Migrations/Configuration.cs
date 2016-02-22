namespace SimilarBeads.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Models;
    
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Cities.Any())
            {
                for (int i = 0; i < 15; i++)
                {
                    var city = new City
                    {
                        Name = $"City{i}"
                    };
                    context.Cities.Add(city);
                }

                context.SaveChanges();
            }

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
                        CityId = 5,
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
                        CityId = 5,
                        Name = $"artist{i}",
                        Subscribers = i * 2
                    };

                    artists.Add(artist);
                    context.Users.Add(artist);
                }

                context.SaveChanges();
            }

            if (!context.Concerts.Any())
            {
                for (int i = 0; i < 50; i++)
                {
                    var concert = new Concert()
                    {
                        Artist = artists[(i + 1) % 10],
                        CityId = 5
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
                        Artist = artists[(i + 1) % 50],
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
