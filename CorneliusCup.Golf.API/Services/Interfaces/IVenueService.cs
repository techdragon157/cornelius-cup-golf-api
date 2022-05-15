using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Requests;
using CorneliusCup.Golf.API.Responses;

namespace CorneliusCup.Golf.API.Services.Interfaces
{
    public interface IVenueService
    {
        public Task<IEnumerable<VenueResponse>> GetVenues();

        public Task<VenueResponse> CreateVenue(VenueRequest venueRequest);

        public Task<VenueResponse> GetVenue(int venueId);

        public Task<int> UpdateVenue(int venueId, VenueRequest venueRequest);

        public Task<int> DeleteVenue(int venueId);

        public Task<IEnumerable<GolfCourseResponse>> GetGolfCourses(int venueId);

        public Task<GolfCourseResponse> CreateGolfCourse(int venueId, GolfCourseRequest golfCourseRequest);

        public Task<GolfCourseResponse> GetGolfCourse(int venueId, int golfCourseId);

        public Task<IEnumerable<TeeResponse>> GetGolfCourseTees(int venueId, int golfCourseId);

        public Task<TeeResponse> GetGolfCourseTee(int venueId, int golfCourseId, int teeId);
    }
}
