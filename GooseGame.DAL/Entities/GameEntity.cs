using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Entities
{
    public class GameEntity : BaseEntity,IEntity
    {

        [Required]
        public DateTime DatePlayed { get; set; }

        public ICollection<PlayerEntity> Players { get; set; } = new List<PlayerEntity>();


        [Required]
        public int WinnerId { get; set; }

        [Required]
        public int ThrowsNeededToWin { get; set; }

        [Range(1, 4)]
        public int AmountOfPlayers { get; set; }
    }
}