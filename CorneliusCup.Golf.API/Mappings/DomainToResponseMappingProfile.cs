using AutoMapper;
using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Responses;

namespace CorneliusCup.Golf.API.Mappings
{
    public class DomainToResponseMappingProfile : Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<Venue, VenueResponse>();
            CreateMap<GolfCourse, GolfCourseResponse>();
            CreateMap<Tee, TeeResponse>();
            CreateMap<HoleDetail, HoleDetailResponse>();
        }

    }
}
