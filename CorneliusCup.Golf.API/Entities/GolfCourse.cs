namespace CorneliusCup.Golf.API.Entities
{
    public class GolfCourse
    {
        public int GolfCourseId { get; set; }

        public string? Name { get; set; }

        public ICollection<Tee> Tees { get; set; } = new List<Tee>();

        public virtual Venue? Venue { get; set; }
    }
}
