namespace SimilarBeads.Web.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;

    public class UserInputModel
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public bool IsArtist { get; set; }
    }
}
