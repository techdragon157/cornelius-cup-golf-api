using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    public class Team
    {
        public int TeamId { get; set; }

        public string? Name { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
