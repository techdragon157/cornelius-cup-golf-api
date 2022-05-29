using CorneliusCup.Golf.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace CorneliusCup.Golf.API.Entities
{
    [Owned]
    public class HoleScore: HoleDetail
    {
        public short Strokes { get; set; }

        public short Stableford { get; set; }

        //public string ScoreTerm => ScoreTerms.getStringRep(this.Strokes, this.Par);

        public bool isHoleInOne => Strokes == 1;
    }
}
