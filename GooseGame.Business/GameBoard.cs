using GooseGame.Business.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GooseGame.Business


{
    public class GameBoard
    {
        TileFactory factory = new();
        public IList<ITile> CreateTileList()
        {
            IList<ITile> listOfTiles = new List<ITile>();
            for (int i = 0; i < 10; i++)
            {
                //if (i == 2)
                //{
                //    listOfTiles.Add(CreateTile(TileType.Aviator));
                //}
                if (i % 3 == 0)
                {
                    listOfTiles.Add(factory.CreateTile(TileType.Goose));
                }
                else if (i % 5 == 0)
                {
                    listOfTiles.Add(factory.CreateTile(TileType.Death));
                }
                else
                {
                    listOfTiles.Add(factory.CreateTile(TileType.Empty));
                }
            }
            return listOfTiles;
        }
    }
}
