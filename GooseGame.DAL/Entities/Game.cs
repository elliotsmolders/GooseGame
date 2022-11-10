using GooseGame.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.DAL.Models
{
    public class Game : BaseEntity
    {
        public DateTime EndTime { get; set; }

        public Player Winner { get; set; }
        public int AmountOfThrows { get; set; }
        public bool IsCompleted { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}