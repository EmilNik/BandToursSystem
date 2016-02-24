namespace SimilarBeads.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        private ICollection<Song> songs;
        private ICollection<Concert> concerts;
        private ICollection<User> favourites;
        private ICollection<Genre> genres;

        public User()
        {
            this.favourites = new HashSet<User>();
            this.songs = new HashSet<Song>();
            this.concerts = new HashSet<Concert>();
            this.genres = new HashSet<Genre>();
        }

        [MaxLength(30)]
        public string Name { get; set; }

        public bool IsArtist { get; set; }

        public bool IsAdmin { get; set; }

        public string AvatarUrl { get; set; }

        public virtual ICollection<User> Favourites
        {
            get { return this.favourites; }
            set { this.favourites = value; }
        }

        [MaxLength(1000)]
        public string Description { get; set; }

        [DefaultValue(0)]
        public int? Subscribers { get; set; }

        public virtual ICollection<Genre> Genres
        {
            get { return this.genres; }
            set { this.genres = value; }
        }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        public virtual ICollection<Concert> Concerts
        {
            get { return this.concerts; }
            set { this.concerts = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            userIdentity.AddClaim(new Claim("IsArtist", this.IsArtist.ToString()));
            userIdentity.AddClaim(new Claim("IsAdmin", this.IsAdmin.ToString()));
            userIdentity.AddClaim(new Claim("Name", this.Name));

            return userIdentity;
        }
    }
}
