using System.ComponentModel.DataAnnotations;

namespace CorneliusCup.Golf.API.Requests
{
    public class PlayerRequest
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public short Handicap { get; set; }
    }
}
