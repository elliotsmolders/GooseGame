using GooseGame.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business.Models
{
    public class PlayerModel
    {
        public string Name { get; set; }

        public int PlayerIcon { get; set; }
    }
}