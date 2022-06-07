using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class Player
    {
        public int PlayerId { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; }

        [MaxLength(320)]
        public string? Email { get; set; }

        public int Handicap { get; set; }

        public ICollection<ScoreCard> ScoreCards { get; set; } = new List<ScoreCard>();

        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
