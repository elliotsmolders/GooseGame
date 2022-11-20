using GooseGame.DAL.Models;
using GooseGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.DAL.Entities
{
    public class Scores : BaseEntity
    {
        public int PlayerId { get; set; }
        public int GamesWon { get; set; }
        public int TotalRolls { get; set; }
        public int WinningRate { get; set; }
    }
}