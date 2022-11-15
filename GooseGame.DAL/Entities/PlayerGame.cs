using GooseGame.DAL.Models;
using GooseGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.DAL.Entities
{
    public class PlayerGame
    {
        public Player Player { get; set; }
           public int PlayerId { get; set; }



            public Game Game { get; set; }
            public int GameId { get; set; }


    }
}
