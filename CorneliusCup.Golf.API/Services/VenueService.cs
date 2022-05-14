using AutoMapper;
using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Requests;
using CorneliusCup.Golf.API.Responses;
using CorneliusCup.Golf.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CorneliusCup.Golf.API.Services
{
    public class VenueService : IVenueService
    {
        private readonly CorneliusCupDbContext _context;
        private readonly IMapper _mapper;

        public VenueService(CorneliusCupDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VenueResponse>> GetVenues()
        {
            var venues = await _context.Venues
                .ToListAsync();

            return _mapper.Map<List<VenueResponse>>(venues);
        }

        public async Task<VenueResponse> CreateVenue(VenueRequest venueRequest)
        {
            var venue = _mapper.Map<Venue>(venueRequest);
            var trackedVenue = await _context.Venues.AddAsync(venue);
            await _context.SaveChangesAsync();

            return _mapper.Map<VenueResponse>(trackedVenue.Entity);
        }

        public async Task<VenueResponse?> GetVenue(int venueId)
        {
            var venue = await _context.Venues
                .SingleOrDefaultAsync(x => x.VenueId == venueId);

            return _mapper.Map<VenueResponse>(venue);
        }

        public async Task<int?> UpdateVenue(int venueId, VenueRequest venueRequest)
        {
            var venue = await _context.Venues
                .SingleOrDefaultAsync(x => x.VenueId == venueId);

            if (venue is null)
            {
                return null;
            }

            _mapper.Map(venueRequest, venue);
            return await _context.SaveChangesAsync();
        }

        public async Task<int?> DeleteVenue(int venueId)
        {
            var venue = await _context.Venues
                .SingleOrDefaultAsync(x => x.VenueId == venueId);

            if (venue is null)
            {
                return null;
            }

            _context.Remove(venue);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GolfCourseResponse>?> GetGolfCourses(int venueId)
        {
            var venue = await _context.Venues
                .Include(x => x.GolfCourses)
                .Where(x => x.VenueId == venueId)
                .SingleOrDefaultAsync();

            if (venue is null)
            {
                return null;
            }

            return _mapper.Map<List<GolfCourseResponse>>(venue.GolfCourses);
        }

        public async Task<GolfCourseResponse?> CreateGolfCourse(int venueId, GolfCourseRequest golfCourseRequest)
        {
            var venue = await _context.Venues
                .SingleOrDefaultAsync(x => x.VenueId == venueId);

            if (venue is null)
            {
                return null;
            }

            var golfcourse = _mapper.Map<GolfCourse>(golfCourseRequest);
            golfcourse.Venue = venue;

            var trackedGolfCourse = await _context.GolfCourses.AddAsync(golfcourse);

            await _context.SaveChangesAsync();

            return _mapper.Map<GolfCourseResponse>(trackedGolfCourse.Entity);
        }

        public async Task<GolfCourseResponse?> GetGolfCourse(int venueId, int golfCourseId)
        {
            var golfCourse = await _context.GolfCourses
                .Where(x => EF.Property<int>(x, "VenueId") == venueId)
                .Where(x => x.GolfCourseId == golfCourseId)
                .SingleOrDefaultAsync();

            if (golfCourse is null)
            {
                return null;
            }

            return _mapper.Map<GolfCourseResponse>(golfCourse);
        }

        public async Task<IEnumerable<TeeResponse>?> GetGolfCourseTees(int venueId, int golfCourseId)
        {
            var golfCourse = await _context.GolfCourses
                .Where(x => EF.Property<int>(x, "VenueId") == venueId)
                .Where(x => x.GolfCourseId == golfCourseId)
                .SingleOrDefaultAsync();

            if (golfCourse is null)
            {
                return null;
            }

            return _mapper.Map<List<TeeResponse>>(golfCourse.Tees);
        }

        public async Task<TeeResponse?> GetGolfCourseTee(int venueId, int golfCourseId, int teeId)
        {
            var golfCourse = await _context.GolfCourses
                .Where(x => EF.Property<int>(x, "VenueId") == venueId)
                .Where(x => x.GolfCourseId == golfCourseId)
                .SingleOrDefaultAsync();

            if (golfCourse is null)
            {
                return null;
            }

            var tee = golfCourse.Tees.SingleOrDefault(x => x.TeeId == teeId);

            if (tee is null)
            {
                return null;
            }

            return _mapper.Map<TeeResponse>(tee);
        }
    }
}
