namespace CorneliusCup.Golf.API.Entities
{
    public class Venue
    {
        public int VenueId { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<GolfCourse> GolfCourses { get; set; } = new List<GolfCourse>();
    }
}
