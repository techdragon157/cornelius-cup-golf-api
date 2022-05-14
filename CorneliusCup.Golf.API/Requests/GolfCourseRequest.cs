namespace CorneliusCup.Golf.API.Requests
{
    public class GolfCourseRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public IEnumerable<TeeRequest> Tees { get; set; } = new List<TeeRequest>();
    }
}
