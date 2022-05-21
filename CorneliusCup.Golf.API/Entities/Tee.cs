using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    [Owned]
    [Index(nameof(TeeType), IsUnique = true)]
    public class Tee<T>
    {
        public int TeeId { get; set; }

        public TeeType TeeType { get; set; }

        [Range(54, 126), Column(TypeName = "smallint")]
        public short Par { get; set; }

        [Range(0, 126), Column(TypeName = "smallint")]
        public short SSS { get; set; }

        [Range(0, 99.9), Precision(3, 1)]
        public decimal CourseRating { get; set; }

        [Range(0, 200), Column(TypeName = "smallint")]
        public short SlopeRating { get; set; }

        public ICollection<T> HoleDetails { get; set; } = new List<T>();
    }

    [Owned]
    public class Tee: Tee<HoleDetail> { }
}
