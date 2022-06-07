using CorneliusCup.Golf.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace CorneliusCup.Golf.API.Entities
{
    [Owned]
    public class HoleScore: HoleDetail
    {
        public int Strokes { get; set; }

        public int Nett { get; set; }

        public int Stableford { get; set; }

        public bool isNoReturn => Strokes == 0;

        public bool isHoleInOne => Strokes == 1;

        public bool isCondor => Strokes - Par == -4;

        public bool isAlbatross => Strokes - Par == -3;

        public bool isEagle => Strokes - Par == -2;

        public bool isBirdie => Strokes - Par == -1;

        public bool isPar => Strokes - Par == 0;
    }
}
