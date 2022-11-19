using GooseGame.DAL.Entities;
using GooseGame.Entities;
using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Models
{
    public class Player : BaseEntity
    {
        [Required]
        public string? PlayerName { get; set; }

        public virtual IList<GamePlayer>? GamePlayers { get; set; }
        // public bool IsNpc { get; set; } // eerst alle andere implementaties, werkend spel
    }
}