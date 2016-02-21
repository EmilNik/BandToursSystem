namespace SimilarBeads.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public virtual User Artist { get; set; }

        public int NumberOfPlays { get; set; }

        public string SongUrl { get; set; }
    }
}
