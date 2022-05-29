using CorneliusCup.Golf.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace CorneliusCup.Golf.API.Entities
{
    [Owned]
    [Index(nameof(Type), IsUnique = true)]
    public class Tee<T>
    {
        public TeeType Type { get; set; }

        public short Par { get; set; }

        public short SSS { get; set; }

        [Precision(3, 1)]
        public decimal CourseRating { get; set; }

        public short SlopeRating { get; set; }

        public ICollection<T> HoleDetails { get; set; } = new List<T>();
    }

    [Owned]
    public class Tee: Tee<HoleDetail> { }
}
