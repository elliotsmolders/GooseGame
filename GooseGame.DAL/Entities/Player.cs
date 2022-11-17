using GooseGame.DAL.Entities;
using GooseGame.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        public string Name { get; set; }
        public string? IconPath { get; set; }
        public int? Sequence { get; set; } // order is een keyword in mssql vandaar sequence
        public int? CurrentPosition { get; set; }
        public virtual IList<PlayerGame>? PlayerGames { get; set; }
        // public bool IsNpc { get; set; } // eerst alle andere implementaties, werkend spel
    }
}