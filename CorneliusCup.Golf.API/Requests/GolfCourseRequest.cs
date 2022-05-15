namespace CorneliusCup.Golf.API.Requests
{
    public class GolfCourseRequest
    {
        public string? Name { get; set; }

        public IEnumerable<TeeRequest> Tees { get; set; } = new List<TeeRequest>();
    }
}
