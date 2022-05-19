﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CorneliusCup.Golf.API.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public int Handicap { get; set; }

        public ICollection<ScoreCard> ScoreCards { get; set; } = new List<ScoreCard>();

        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
