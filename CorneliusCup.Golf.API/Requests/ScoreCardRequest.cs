namespace CorneliusCup.Golf.API.Requests
{
    public class ScoreCardRequest
    {
        public int Handicap { get; set; }

        public TeeRequest<HoleScoreRequest>? Tee { get; set; }

        public int CompetitionId { get; set; }

        public int VenueId { get; set; }

        public int GolfCourseId { get; set; }
    }
}
