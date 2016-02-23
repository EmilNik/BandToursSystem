namespace SimilarBeads.Web.ViewModels.Artist
{
    using System.Linq;

    using AutoMapper;
    using Infrastructure.Mapping;

    public class ArtistViewModel : IMapFrom<Data.Models.User>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int? Subscribers { get; set; }

        public int SongsPlays { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.User, ArtistViewModel>()
                .ForMember(x => x.Subscribers, opt => opt.MapFrom(x => x.Subscribers == null ? 0 : x.Subscribers))
                .ForMember(x => x.SongsPlays, opt => opt.MapFrom(x => x.Songs.Any() ? x.Songs.Sum(s => s.NumberOfPlays) : 0));
        }
    }
}
