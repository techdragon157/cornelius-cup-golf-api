using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    public class ScoreCard
    {
        public int ScoreCardId { get; set; }

        [Range(0, 54), Column(TypeName = "smallint")]
        public short Handicap { get; set; }

        [Range(0, 108), Column(TypeName = "smallint")]
        public short Stableford { get; set; }

        [Range(0, 999), Column(TypeName = "smallint")]
        public short Gross { get; set; }

        [Range(0, 999), Column(TypeName = "smallint")]
        public short Nett { get; set; }

        public Tee<HoleScore>? Tee { get; set; }

        public int PlayerId { get; set; }
        public Player? Player { get; set; }

        public int CompetitionId { get; set; }
        public Competition? Competition { get; set; }

        public int GolfCourseId { get; set; }
        public GolfCourse? GolfCourse { get; set; }
    }
}
