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
        [Key]
        public int Id { get; set; }

        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
    }
}