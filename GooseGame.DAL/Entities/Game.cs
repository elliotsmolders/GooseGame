using GooseGame.Entities;
using System;
using System.Collections.Generic;
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
    }
}