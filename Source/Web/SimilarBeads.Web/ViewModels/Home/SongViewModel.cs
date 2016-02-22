namespace SimilarBeads.Web.ViewModels.Home
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class SongViewModel : IMapFrom<Song>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public virtual ArtistViewModel Artist { get; set; }

        public int NumberOfPlays { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Song, SongViewModel>()
                .ForMember(x => x.Artist, opt => opt.MapFrom(x => x.Artist));
        }
    }
}
