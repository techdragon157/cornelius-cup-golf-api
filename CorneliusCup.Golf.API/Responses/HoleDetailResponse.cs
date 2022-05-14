using CorneliusCup.Golf.API.Entities;

namespace CorneliusCup.Golf.API.Responses
{
    public class HoleDetailResponse
    {
        public int Number { get; set; }

        public int Yards { get; set; }

        public int Par { get; set; }

        public int StrokeIndex { get; set; }
    }

}
