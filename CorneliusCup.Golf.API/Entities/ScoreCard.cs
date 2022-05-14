using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    public class ScoreCard
    {
        public int ScoreCardId { get; set; }

        public int Handicap { get; set; }

        public int Stableford { get; set; }

        public int Gross { get; set; }

        public int Nett { get; set; }

        public ICollection<Tee<HoleScore>> Tees { get; set; } = new List<Tee<HoleScore>>();

        public Player? Player { get; set; }

        public Competition? Competition { get; set; }

        public GolfCourse? GolfCourse { get; set; }
    }
}
