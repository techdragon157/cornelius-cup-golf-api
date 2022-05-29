using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    public class ScoreCard
    {
        public int ScoreCardId { get; set; }

        public short Handicap { get; set; }

        public short Stableford { get; set; }

        public short Gross { get; set; }

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
