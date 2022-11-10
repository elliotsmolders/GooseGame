using GooseGame.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.DAL.Models
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public int CurrentPosition { get; set; }
        private bool IsNpc { get; set; } = false;
        private int NumberOfThrows { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}