namespace SimilarBeads.Web.ViewModels.User
{
    using System.Collections.Generic;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Song;

    public class UserProfileViewModel : IMapFrom<Data.Models.User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public int? Subscribers { get; set; }

        public bool IsArtist { get; set; }

        public ICollection<SongViewModel> Songs { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.User, UserProfileViewModel>()
                .ForMember(x => x.Subscribers, opt => opt.MapFrom(x => x.Subscribers == null ? 0 : x.Subscribers));
        }
    }
}
