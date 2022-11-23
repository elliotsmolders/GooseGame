using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.DAL.Entities
{
    public interface IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
