namespace SimilarBeads.Data.Models
{
    using System.Collections.Generic;

    public class User : ApplicationUser
    {
        private ICollection<Artist> favourites;

        public User()
        {
            this.favourites = new HashSet<Artist>();
        }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Artist> Favourites
        {
            get { return this.favourites; }
            set { this.favourites = value; }
        }

        public virtual ICollection<Genre> Genres { get; set; }
    }
}
