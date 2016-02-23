namespace SimilarBeads.Web.ViewModels.City
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;

    public class CityViewModel : IMapFrom<Data.Models.City>
    {
        public string Name { get; set; }
    }
}
