using GooseGame.Business.Tiles;

namespace GooseGame.Business.Factory
{
    public class TileFactory
    {
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
                    listOfTiles.Add(CreateTile(TileType.Goose));
                }
                else if (i % 5 == 0)
                {
                    listOfTiles.Add(CreateTile(TileType.Death));
                }
                else
                {
                    listOfTiles.Add(CreateTile(TileType.Empty));
                }
            }
            return listOfTiles;
        }

        private ITile CreateTile(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return new BridgeTile();

                case TileType.Death:
                    return new DeathTile();

                case TileType.Goose:
                    return new GooseTile();

                case TileType.Prison:
                    throw new NotImplementedException();
                case TileType.Aviator:
                    return new AviatorTile();
            }
            return null!;
        }
    }
}