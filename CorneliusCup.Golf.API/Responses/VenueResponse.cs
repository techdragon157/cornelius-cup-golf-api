namespace CorneliusCup.Golf.API.Responses
{
    public class VenueResponse
    {
        public int VenueId { get; set; }

        public string? Name { get; set; }

        public virtual IEnumerable<GolfCourseResponse> GolfCourses { get; set; } = new List<GolfCourseResponse>();
    }
}
