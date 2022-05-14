using CorneliusCup.Golf.API.Entities;

namespace CorneliusCup.Golf.API.Requests
{
    public class HoleDetailRequest
    {
        public int Number { get; set; }

        public int Yards { get; set; }

        public int Par { get; set; }

        public int StrokeIndex { get; set; }
    }

}
