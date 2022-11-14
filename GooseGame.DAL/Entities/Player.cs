using GooseGame.Entities;
using Microsoft.EntityFrameworkCore;

namespace GooseGame.DAL.Models
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public int Sequence { get; set; } // order is een keyword in mssql vandaar sequence
        public int CurrentPosition { get; set; }
        public DbSet<Game> Games { get; set; }
        // public bool IsNpc { get; set; } // eerst alle andere implementaties, werkend spel
    }
}