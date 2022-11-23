using GooseGame.Business.Factory;
using GooseGame.Business.Interfaces;
using GooseGame.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            FillTileList();
        }

        public static GameBoard GetGameBoard()
        {
            if (_gameBoard == null)
            {
                _gameBoard = new GameBoard();
            }
            return _gameBoard;
        }

        public IList<ITile> Tiles { get; set; } = new List<ITile>(); // ListOf doen we niet meer

        public int AmountOfTiles = 64;
        private int[] GooseTilePositions = { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };
        private int[] StartTilePositions = { 0 };
        private int[] PrisonTilePositions = { 52 };
        private int[] BridgeTilePositions = { 6 };
        private int[] InnTilePositions = { 19 };
        private int[] WellTilePositions = { 31 };
        private int[] MazeTilePositions = { 42 };
        private int[] DeathTilePositions = { 58 };
        public const int EndTilePosition =  63 ;

        private static GameBoard _gameBoard;

        /// <summary>
        /// private fields moeten toch met _
        /// https://stackoverflow.com/questions/450238/to-underscore-or-to-not-to-underscore-that-is-the-question
        /// </summary>
        private TileFactory _factory = new();

        private void FillTileList()
        {
            for (int i = 0; i < AmountOfTiles; i++)
            {
                if (GooseTilePositions.Contains(i))
                {
                    Tiles.Add(_factory.CreateTile(TileType.Goose, i));
                }
                else if(StartTilePositions.Contains(i)){
                    Tiles.Add(_factory.CreateTile(TileType.Start, i));
                }
                else if (PrisonTilePositions.Contains(i))
                {
                    Tiles.Add(_factory.CreateTile(TileType.Prison, i));
                }
                else if (BridgeTilePositions.Contains(i))
                {
                    Tiles.Add(_factory.CreateTile(TileType.Bridge, i));
                }
                else if (InnTilePositions.Contains(i))
                {
                    Tiles.Add(_factory.CreateTile(TileType.Inn, i));
                }
                else if (WellTilePositions.Contains(i))
                {
                    Tiles.Add(_factory.CreateTile(TileType.Well, i));
                }
                else if (MazeTilePositions.Contains(i))
                {
                    Tiles.Add(_factory.CreateTile(TileType.Maze, i));
                }
                else if (DeathTilePositions.Contains(i))
                {
                    Tiles.Add(_factory.CreateTile(TileType.Death, i));
                }
                else if (EndTilePosition == i)
                {
                    Tiles.Add(_factory.CreateTile(TileType.End, i));
                }
                else Tiles.Add(_factory.CreateTile(TileType.Empty, i));
            }
        }
    }
}
