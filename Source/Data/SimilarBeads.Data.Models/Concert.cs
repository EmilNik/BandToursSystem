namespace SimilarBeads.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Concert
    {
        [Key]
        public int Id { get; set; }

        public int? CityId { get; set; }

        public virtual City City { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public Artist Artist { get; set; }
    }
}