namespace SimilarBeads.Web.Areas.Admin.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Infrastructure.Mapping;

    public class UserInputModel : IMapFrom<User>
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
