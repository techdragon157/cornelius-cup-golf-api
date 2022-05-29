using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Competition
    {
        public int CompetitionId { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; }

        public DateOnly startDate  { get; set; }

        [Required]
        public DateOnly endDate { get; set; }

        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
