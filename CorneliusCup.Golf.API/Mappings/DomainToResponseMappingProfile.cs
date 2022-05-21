using AutoMapper;
using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Responses;

namespace CorneliusCup.Golf.API.Mappings
{
    public class DomainToResponseMappingProfile : Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<Resort, ResortResponse>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.ResortId)
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

            CreateMap<Player, PlayerResponse>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.PlayerId)
                );

            CreateMap<ScoreCard, ScoreCardResponse>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.ScoreCardId)
                );
        }

    }
}
