namespace SimilarBeads.Web.ViewModels.User
{
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<Data.Models.User>
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
