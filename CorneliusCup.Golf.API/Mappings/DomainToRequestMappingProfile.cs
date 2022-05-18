using AutoMapper;
using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Requests;

namespace CorneliusCup.Golf.API.Mappings
{
    public class DomainToRequestMappingProfile : Profile
    {
        public DomainToRequestMappingProfile()
        {
            CreateMap<VenueRequest, Venue>();
            //.ForMember(
            //    dest => dest.VenueId,
            //    opt => opt.MapFrom(src => src.Id)
            //);

            CreateMap<GolfCourseRequest, GolfCourse>();
            //.ForMember(
            //    dest => dest.GolfCourseId,
            //    opt => opt.MapFrom(src => src.Id)
            //);

            CreateMap<TeeRequest, Tee>();
            //.ForMember(
            //    dest => dest.TeeId,
            //    opt => opt.MapFrom(src => src.Id)
            //);

            CreateMap<HoleDetailRequest, HoleDetail>();

            CreateMap<PlayerRequest, Player>();
        }

    }
}
