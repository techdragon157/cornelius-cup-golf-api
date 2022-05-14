using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    public class Competition
    {
        public int CompetitionId { get; set; }

        public string? Name { get; set; }

        public DateOnly startDate  { get; set; }

        public DateOnly endDate { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
