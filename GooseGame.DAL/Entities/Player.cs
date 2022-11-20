using GooseGame.DAL.Entities;
using GooseGame.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Models
{
    public class Player : BaseEntity
    {
        [Required]
        public string? PlayerName { get; set; }

        public virtual ICollection<GamePlayer>? GamePlayers { get; set; }

        public virtual Scores? GlobalPlayerScore { get; set; }
    }
}