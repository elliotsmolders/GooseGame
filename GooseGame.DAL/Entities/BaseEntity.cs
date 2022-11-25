using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Entities
{
    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}