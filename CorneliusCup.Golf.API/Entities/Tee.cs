using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CorneliusCup.Golf.API.Entities
{
    [Owned]
    public class Tee<T>
    {
        public TeeType TeeType { get; set; }

        public int Par { get; set; }

        public int SSS { get; set; }

        public int CourseRating { get; set; }

        public int SlopeRating { get; set; }

        public ICollection<T> HoleDetails { get; set; } = new List<T>();
    }

    [Owned]
    public class Tee: Tee<HoleDetail> { }
}
