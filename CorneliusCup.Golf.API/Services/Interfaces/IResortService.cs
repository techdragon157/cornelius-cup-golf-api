using CorneliusCup.Golf.API.Entities;
using CorneliusCup.Golf.API.Requests;
using CorneliusCup.Golf.API.Responses;

namespace CorneliusCup.Golf.API.Services.Interfaces
{
    public interface IResortService
    {
        public Task<IEnumerable<ResortResponse>> GetResorts();

        public Task<ResortResponse> CreateResort(ResortRequest resortRequest);

        public Task<ResortResponse> GetResort(int resortId);

        public Task<int> UpdateResort(int resortId, ResortRequest resortRequest);

        public Task<int> DeleteResort(int resortId);

        public Task<IEnumerable<GolfCourseResponse>> GetGolfCourses(int resortId);

        public Task<GolfCourseResponse> CreateGolfCourse(int resortId, GolfCourseRequest golfCourseRequest);

        public Task<GolfCourseResponse> GetGolfCourse(int resortId, int golfCourseId);

        public Task<IEnumerable<TeeResponse>> GetGolfCourseTees(int resortId, int golfCourseId);

        public Task<TeeResponse> GetGolfCourseTee(int resortId, int golfCourseId, string teeType);
    }
}
