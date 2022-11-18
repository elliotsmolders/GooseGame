using GooseGame.DAL.Entities;
using GooseGame.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Models
{
    public class Game : BaseEntity
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public GameBoard GameBoard { get; set; }

        public virtual IList<PlayerGame> PlayerGames { get; set; }
        public int AmountOfThrows { get; set; }
        public Player? Winner { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; } // is struct dus verplicht op stack vandaar ?
        // public bool IsCompleted { get; set; } // redundant eens end time bekend is
    }
}