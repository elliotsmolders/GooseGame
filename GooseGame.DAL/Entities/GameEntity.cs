using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GooseGame.DAL.Entities
{
    public class GameEntity : BaseEntity, IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }

        [Required]
        public DateTime DatePlayed { get; set; }

        public ICollection<PlayerEntity> Players { get; set; }

        [Required]
        public int WinnerId { get; set; }

        [Required]
        public int ThrowsNeededToWin { get; set; }

        [Range(1, 4)]
        public int AmountOfPlayers { get; set; }
    }
}