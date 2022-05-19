namespace CorneliusCup.Golf.API.Entities
{
    public class GolfCourse
    {
        public int GolfCourseId { get; set; }

        public string? Name { get; set; }

        public ICollection<Tee> Tees { get; set; } = new List<Tee>();

        public int VenueId { get; set; }
        public Venue? Venue { get; set; }
    }
}
