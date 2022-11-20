using GooseGame.Business.Interfaces;
using GooseGame.Business.Tiles;
using GooseGame.DAL.Entities;

namespace GooseGame.Business.Factory
{
    public class TileFactory
    {
        public ITile CreateTile(TileType type)
        {
            switch (type)
            {
                case TileType.Default:
                    return new DefaultTile();

                case TileType.Start:
                    return new StartTile();

                case TileType.Death:
                    return new DeathTile();

                case TileType.Goose:
                    return new GooseTile();

                case TileType.Prison:
                    return new PrisonTile();

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

                case TileType.Bridge:
                    return new BridgeTile();

                default:
                    throw new Exception($"Tile not supported  {nameof(type)}  {type}");
            }
            return null!;
        }
    }
}