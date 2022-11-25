using GooseGame.Business.Interfaces;
using GooseGame.Business.Tiles;
using GooseGame.DAL.Entities;

namespace GooseGame.Business.Factory
{
    public class TileFactory
    {
        /// <summary>
        /// Creates a predefined type of tile
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tileId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ITile CreateTile(TileType type, int tileId)
        {
            switch (type)
            {
                case TileType.Empty:
                    return new EmptyTile(tileId);

                case TileType.Start:
                    return new StartTile(tileId);

                case TileType.Death:
                    return new DeathTile(tileId);

                case TileType.Goose:
                    return new GooseTile(tileId);

                case TileType.Prison:
                    return new PrisonTile(tileId);

                case TileType.Inn:
                    return new InnTile(tileId);

                case TileType.Well:
                    return new WellTile(tileId);

                case TileType.Maze:
                    return new MazeTile(tileId);

                case TileType.End:
                    return new EndTile(tileId);

                case TileType.Bridge:
                    return new BridgeTile(tileId);

                default:
                    throw new Exception($"Tile not supported  {nameof(type)}  {type}");
            }
        }
    }
}