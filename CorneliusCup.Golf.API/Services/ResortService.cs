using AutoMapper;
using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Requests;
using CorneliusCup.Golf.API.Responses;
using CorneliusCup.Golf.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CorneliusCup.Golf.API.Services
{
    public class ResortService : IResortService
    {
        private readonly CorneliusCupDbContext _context;
        private readonly IMapper _mapper;

        public ResortService(CorneliusCupDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResortResponse>> GetResorts()
        {
            var resorts = await _context.Resorts
                .ToListAsync();

            return _mapper.Map<List<ResortResponse>>(resorts);
        }

        public async Task<ResortResponse> CreateResort(ResortRequest resortRequest)
        {
            var resort = _mapper.Map<Resort>(resortRequest);
            var trackedResort = await _context.Resorts.AddAsync(resort);
            await _context.SaveChangesAsync();

            return _mapper.Map<ResortResponse>(trackedResort.Entity);
        }

        public async Task<ResortResponse> GetResort(int resortId)
        {
            var resort = await _context.Resorts
                .SingleAsync(x => x.ResortId == resortId);

            return _mapper.Map<ResortResponse>(resort);
        }

        public async Task<int> UpdateResort(int resortId, ResortRequest resortRequest)
        {
            var resort = await _context.Resorts
                .SingleAsync(x => x.ResortId == resortId);

            _mapper.Map(resortRequest, resort);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteResort(int resortId)
        {
            var resort = await _context.Resorts
                .SingleAsync(x => x.ResortId == resortId);

            _context.Remove(resort);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GolfCourseResponse>> GetGolfCourses(int resortId)
        {
            var resort = await _context.Resorts
                .Include(x => x.GolfCourses)
                .Where(x => x.ResortId == resortId)
                .SingleAsync();

            return _mapper.Map<List<GolfCourseResponse>>(resort.GolfCourses);
        }

        public async Task<GolfCourseResponse> CreateGolfCourse(int resortId, GolfCourseRequest golfCourseRequest)
        {
            var resort = await _context.Resorts
                .SingleAsync(x => x.ResortId == resortId);

            var golfcourse = _mapper.Map<GolfCourse>(golfCourseRequest);
            golfcourse.Resort = resort;

            var trackedGolfCourse = await _context.GolfCourses.AddAsync(golfcourse);

            await _context.SaveChangesAsync();

            return _mapper.Map<GolfCourseResponse>(trackedGolfCourse.Entity);
        }

        public async Task<GolfCourseResponse> GetGolfCourse(int resortId, int golfCourseId)
        {
            var golfCourse = await _context.GolfCourses
                .Where(x => x.ResortId == resortId)
                .Where(x => x.GolfCourseId == golfCourseId)
                .SingleAsync();

            return _mapper.Map<GolfCourseResponse>(golfCourse);
        }

        public async Task<IEnumerable<TeeResponse>> GetGolfCourseTees(int resortId, int golfCourseId)
        {
            var golfCourse = await _context.GolfCourses
                .Where(x => x.ResortId == resortId)
                .Where(x => x.GolfCourseId == golfCourseId)
                .SingleAsync();

            return _mapper.Map<List<TeeResponse>>(golfCourse.Tees);
        }

        public async Task<TeeResponse> GetGolfCourseTee(int resortId, int golfCourseId, int teeId)
        {
            var golfCourse = await _context.GolfCourses
                .Where(x => x.ResortId == resortId)
                .Where(x => x.GolfCourseId == golfCourseId)
                .SingleAsync();

            var tee = golfCourse.Tees.Single(x => x.TeeId == teeId);

            return _mapper.Map<TeeResponse>(tee);
        }
    }
}
