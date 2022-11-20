using GooseGame.Business.Factory;
using GooseGame.Business.Interfaces;
using GooseGame.DAL.Entities;

namespace GooseGame.Business
{
    /// <summary>
    /// + heel belangrijke reden , we komen in problemen bij het bijvoorbeeld restoren van een spel uit de DB
    ///
    /// GameBoard mag ook naar DAL als entity als we het board willen opslagen wat wel een goed idee is
    /// als we meerdere soorten borden zouden maken versies.
    /// </summary>
    public class GameBoard
    {
        private GameBoard()
        {
            Tiles = CreateTileList();
        }

        public static GameBoard GetGameBoard()
        {
            if (_gameBoard == null)
            {
                _gameBoard = new GameBoard();
            }
            return _gameBoard;
        }

        public IList<ITile> Tiles { get; set; }

        public readonly int[] GooseTilePositions = { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };
        public const int StartTilePosition = 0;
        public const int PrisonTilePosition = 52;
        public const int BridgeTilePosition = 6;
        public const int InnTilePosition = 19;
        public const int WellTilePosition = 31;
        public const int MazeTilePosition = 42;
        public const int DeathTilePosition = 58;
        public const int EndTilePosition = 63;

        private static GameBoard? _gameBoard;

        /// <summary>
        /// private fields moeten toch met _
        /// https://stackoverflow.com/questions/450238/to-underscore-or-to-not-to-underscore-that-is-the-question
        /// </summary>
        private readonly TileFactory _factory = new();

        private List<ITile> CreateTileList()
        {
            List<ITile> retval = new();
            for (int i = StartTilePosition; i <= EndTilePosition; i++)
            {
                if (GooseTilePositions.Contains(i))
                {
                    retval.Add(_factory.CreateTile(TileType.Goose));
                }
                else if (i == StartTilePosition)
                {
                    retval.Add(_factory.CreateTile(TileType.Start));
                }
                else if (i == PrisonTilePosition)
                {
                    retval.Add(_factory.CreateTile(TileType.Prison));
                }
                else if (i == BridgeTilePosition)
                {
                    retval.Add(_factory.CreateTile(TileType.Bridge));
                }
                else if (i == InnTilePosition)
                {
                    retval.Add(_factory.CreateTile(TileType.Inn));
                }
                else if (i == WellTilePosition)
                {
                    retval.Add(_factory.CreateTile(TileType.Well));
                }
                else if (i == MazeTilePosition)
                {
                    retval.Add(_factory.CreateTile(TileType.Maze));
                }
                else if (i == DeathTilePosition)
                {
                    retval.Add(_factory.CreateTile(TileType.Death));
                }
                else if (i == EndTilePosition)
                {
                    retval.Add(_factory.CreateTile(TileType.End));
                }
                else
                {
                    retval.Add(_factory.CreateTile(TileType.Default));
                }
            }
            return retval;
        }
    }
}