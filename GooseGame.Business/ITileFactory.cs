using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business
{
    public interface ITileFactory
    {
        public void DrawTile()
        {
            Console.WriteLine("tile");
        }
    }
}
