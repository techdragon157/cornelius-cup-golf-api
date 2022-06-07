using CorneliusCup.Golf.API.Enums;

namespace CorneliusCup.Golf.API.Responses
{
    public class TeeResponse<T>
    {
        public TeeType Type { get; set; }

        public int Par { get; set; }

        public int SSS { get; set; }

        public decimal CourseRating { get; set; }

        public int SlopeRating { get; set; }

        public IEnumerable<T> HoleDetails { get; set; } = new List<T>();
    }

    public class TeeResponse : TeeResponse<HoleDetailResponse> { }

}
