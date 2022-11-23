using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.DAL.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get ; set ; }
        public DateTime DateUpdated { get ; set ; } = DateTime.Now;
    }
}
