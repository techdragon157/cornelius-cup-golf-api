using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CorneliusCup.Golf.API.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class GolfCourse
    {
        public int GolfCourseId { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; }

        public virtual ICollection<Tee> Tees { get; set; } = new List<Tee>();

        public int ResortId { get; set; }
        public Resort? Resort { get; set; }
    }
}
