using CorneliusCup.Golf.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace CorneliusCup.Golf.API.Entities
{
    [Owned]
    [Index(nameof(Type), IsUnique = true)]
    public class Tee<T>
    {
        public int TeeId { get; set; }

        public TeeType Type { get; set; }

        public int Par { get; set; }

        public int SSS { get; set; }

        [Precision(3, 1)]
        public decimal CourseRating { get; set; }

        public int SlopeRating { get; set; }

        public ICollection<T> HoleDetails { get; set; } = new List<T>();
    }

    [Owned]
    public class Tee: Tee<HoleDetail> { }
}
