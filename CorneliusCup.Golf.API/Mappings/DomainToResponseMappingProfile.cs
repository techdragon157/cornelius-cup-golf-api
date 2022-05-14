using AutoMapper;
using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Responses;

namespace CorneliusCup.Golf.API.Mappings
{
    public class DomainToResponseMappingProfile : Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<Venue, VenueResponse>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.VenueId)
                );

            CreateMap<GolfCourse, GolfCourseResponse>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.GolfCourseId)
                );

            CreateMap<Tee, TeeResponse>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.TeeId)
                );

            CreateMap<HoleDetail, HoleDetailResponse>();
        }

    }
}
