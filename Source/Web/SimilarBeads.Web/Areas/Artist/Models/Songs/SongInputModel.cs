namespace SimilarBeads.Web.ViewModels.Song
{
    using System.ComponentModel.DataAnnotations;

    public class SongInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
