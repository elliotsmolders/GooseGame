using GooseGame.Business.Tiles;

namespace GooseGame.Business.Factory
{
    public class TileFactory
    {


        public ITile CreateTile(TileType type)
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
                case TileType.Inn:
                    return new InnTile();
                case TileType.Well:
                    return new WellTile();
                case TileType.Maze:
                    return new MazeTile();
                case TileType.End:
                    return new EndTile();
            }
            return null!;
        }
    }
}