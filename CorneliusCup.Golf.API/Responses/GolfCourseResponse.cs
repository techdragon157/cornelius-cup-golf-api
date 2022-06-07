namespace CorneliusCup.Golf.API.Responses
{
    public class GolfCourseResponse
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public IEnumerable<TeeResponse> Tees { get; set; } = new List<TeeResponse>();
    }
}
