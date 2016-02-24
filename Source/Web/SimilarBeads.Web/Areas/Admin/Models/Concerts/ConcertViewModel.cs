namespace SimilarBeads.Web.Areas.Admin.Models.Concerts
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ConcertViewModel : IMapFrom<Concert>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Concert, ConcertViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(a => a.Artist.Name));
        }
    }
}
