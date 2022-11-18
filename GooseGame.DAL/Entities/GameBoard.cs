using GooseGame.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Entities
{
    public class GameBoard : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public virtual DbSet<Tile> Tiles { get; set; }
    }
}