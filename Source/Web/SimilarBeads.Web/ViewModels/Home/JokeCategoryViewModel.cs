namespace SimilarBeads.Web.ViewModels.Home
{
    using SimilarBeads.Data.Models;
    using SimilarBeads.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
