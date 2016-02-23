namespace SimilarBeads.Web.ViewModels.User
{
    using AutoMapper;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<Data.Models.User>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.User, UserViewModel>()
                .ForMember(x => x.City, opt => opt.MapFrom(x => x.City.Name));
        }
    }
}
