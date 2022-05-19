namespace CorneliusCup.Golf.API.Responses
{
    public class ScoreCardResponse
    {
        public int Id { get; set; }

        public int Handicap { get; set; }

        public int Stableford { get; set; }

        public int Gross { get; set; }

        public int Nett { get; set; }

        public TeeResponse<HoleScoreResponse>? Tee { get; set; }
    }
}
