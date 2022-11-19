using GooseGame.DAL.Models;
using GooseGame.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.DAL.Entities
{
    public class GamePlayer
    {
        [Required]
        public Player? Player { get; set; }

        public int PlayerId { get; set; }

        [Required]
        public Game? Game { get; set; }

        public int GameId { get; set; }

        [Required]
        public Icon? Icon { get; set; }

        [Required]
        public int? PlayerSequence { get; set; } // order is een keyword in mssql vandaar sequence

        [Required]
        public int? PlayerPosition { get; set; }
    }
}