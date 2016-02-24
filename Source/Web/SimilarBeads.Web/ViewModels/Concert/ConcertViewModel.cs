namespace SimilarBeads.Web.ViewModels.Concert
{
    using System;
    using AutoMapper;
    using Infrastructure.Mapping;

    public class ConcertViewModel : IMapFrom<Data.Models.Concert>, IHaveCustomMappings
    {
        public string City { get; set; }

        public string Artist { get; set; }

        public DateTime Date { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.Concert, ConcertViewModel>()
                .ForMember(x => x.Artist, opt => opt.MapFrom(x => x.Artist.Name));
        }
    }
}
