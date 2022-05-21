using CorneliusCup.Golf.API.Entities;

namespace CorneliusCup.Golf.API.Requests
{
    public class HoleScoreRequest : HoleDetailRequest
    {
        public int Strokes { get; set; }
    }

}
