namespace SimilarBeads.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        private ICollection<Concert> concerts;

        public City()
        {
            this.concerts = new HashSet<Concert>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<Concert> Concerts
        {
            get { return this.concerts; }
            set { this.concerts = value; }
        }
    }
}