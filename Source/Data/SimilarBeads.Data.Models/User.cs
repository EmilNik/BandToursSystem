namespace SimilarBeads.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : ApplicationUser
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

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<User> Favourites
        {
            get { return this.favourites; }
            set { this.favourites = value; }
        }

        // Artists
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public int Subscribers { get; set; }

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
    }
}
