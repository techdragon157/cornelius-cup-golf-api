using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    public class Team
    {
        public int TeamId { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
