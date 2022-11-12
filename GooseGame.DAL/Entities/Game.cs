using GooseGame.Entities;
using Microsoft.EntityFrameworkCore;

namespace GooseGame.DAL.Models
{
    public class Game : BaseEntity
    {
        public DbSet<Player> Players { get; set; }
        public int AmountOfThrows { get; set; }
        public Player Winner { get; set; }
        public DateTime? EndTime { get; set; } // is struct dus verplicht op stack vandaar ?
        // public bool IsCompleted { get; set; } // redundant eens end time bekend is
    }
}