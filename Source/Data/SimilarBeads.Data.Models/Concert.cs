namespace SimilarBeads.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Concert
    {
        [Key]
        public int Id { get; set; }

        public string City { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public User Artist { get; set; }

        public DateTime Date { get; set; }
    }
}
