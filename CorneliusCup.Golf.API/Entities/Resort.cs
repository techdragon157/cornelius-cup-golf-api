using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CorneliusCup.Golf.API.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Resort
    {
        public int ResortId { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; }

        public virtual ICollection<GolfCourse> GolfCourses { get; set; } = new List<GolfCourse>();
    }
}
