using GooseGame.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Entities
{
    public class GameBoard : BaseEntity
    {
        public virtual ICollection<Tile>? Tiles { get; set; }
    }
}