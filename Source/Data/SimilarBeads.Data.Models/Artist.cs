namespace SimilarBeads.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artist : ApplicationUser
    {
        private ICollection<Song> songs;
        private ICollection<Concert> concerts;

        public Artist()
        {
            this.songs = new HashSet<Song>();
            this.concerts = new HashSet<Concert>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public int Subscribers { get; set; }

        public virtual Genre Genre { get; set; }

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
