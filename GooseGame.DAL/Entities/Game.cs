using GooseGame.DAL.Entities;
using GooseGame.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GooseGame.DAL.Models
{
    public class Game : BaseEntity
    {
        [Required]
        public GameBoard GameBoard { get; set; }

        public virtual ICollection<GamePlayer>? GamePlayers { get; set; }

        public int AmountOfThrows { get; set; }

        public Player? Winner { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; } // is struct dus verplicht op stack vandaar ?
        // public bool IsCompleted { get; set; } // redundant eens end time bekend is
    }
}