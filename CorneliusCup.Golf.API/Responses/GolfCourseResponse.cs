namespace CorneliusCup.Golf.API.Responses
{
    public class GolfCourseResponse
    {
        public int GolfCourseId { get; set; }

        public string? Name { get; set; }

        public IEnumerable<TeeResponse> Tees { get; set; } = new List<TeeResponse>();
    }
}
