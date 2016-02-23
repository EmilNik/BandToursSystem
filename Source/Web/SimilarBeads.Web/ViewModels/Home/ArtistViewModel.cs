namespace SimilarBeads.Web.ViewModels.Home
{
    using System.Linq;

    using AutoMapper;
    using Infrastructure.Mapping;

    public class ArtistViewModel : IMapFrom<Data.Models.User>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int? Subscribers { get; set; }

        public int? SongsPlays { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.User, ArtistViewModel>()
                .ForMember(x => x.SongsPlays, opt => opt.MapFrom(x => x.Songs.Sum(s => s.NumberOfPlays)));
        }
    }
}
