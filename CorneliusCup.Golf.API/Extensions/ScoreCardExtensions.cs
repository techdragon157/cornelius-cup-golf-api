using CorneliusCup.Golf.API.Entities;

namespace CorneliusCup.Golf.API.Extensions
{
    public static class ScoreCardExtensions
    {
        public static void CalculateScores(this ScoreCard scoreCard)
        {
            var tee = scoreCard.Tee;
            
            if(tee is null)
            {
                throw new InvalidOperationException("Tee is Null: Can't calculate scores without a Tee");
            }

            foreach (var holeDetail in tee.HoleDetails)
            {
                holeDetail.Nett = 0;
                holeDetail.Stableford = 0;

                if (holeDetail.Strokes > 0)
                {
                    var strokeAllowance = StrokeAllowance(scoreCard.Handicap, holeDetail.StrokeIndex);

                    holeDetail.Nett = holeDetail.Strokes - strokeAllowance;
                    holeDetail.Stableford = getStableFordPoints(holeDetail.Nett - holeDetail.Par);
                }
            }

            scoreCard.Gross = tee.HoleDetails.Aggregate(0, (total, next) => total + next.Strokes);
            scoreCard.Nett = tee.HoleDetails.Aggregate(0, (total, next) => total + next.Nett);
            scoreCard.Stableford = tee.HoleDetails.Aggregate(0, (total, next) => total + next.Stableford);
        }

        private static int StrokeAllowance(int handicap, int strokeIndex)
        {
            var baseAllowance = (int)Math.Floor((decimal)handicap / 18);
            var adjustment = (handicap % 18) - strokeIndex;

            return adjustment >= 0 ? baseAllowance + 1 : baseAllowance;
        }

        private static short getStableFordPoints(int adjustedScore)
        {
            switch (adjustedScore)
            {
                case <= -4:
                    return 6;
                case -3:
                    return 5;
                case -2:
                    return 4;
                case -1:
                    return 3;
                case 0:
                    // par
                    return 2;
                case 1:
                    return 1;
                case > 1:
                    return 0;
            }
        }
    }
}
