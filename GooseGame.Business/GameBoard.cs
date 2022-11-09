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

        public GameBoard()
        {
            FillTileList();
        }
        public IList<ITile> listOfTiles { get; set; }


        private const int _amountOfTiles = 63;
        int[] EmptyTilePositions = {1,2, 3,4, 7,8,10,11,13,15,16,17,20,21,22,24,25,26,28,29,30,33,34,35,37,38,39,40,43,44,46,47,48,49,51,53,55,56,57,60,61,62};
        int[] GooseTilePositions = { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };

        int[] PrisonTilePositions = { 52 };

        int[] BridgeTilePositions = { 6, 12 };
        int[] InnTilePositions = { 19 };
        int[] WellTilePositions = { 31 };
        int[] MazeTilePositions = { 42 };
        int[] DeathTilePositions = { 58 };
        int[] EndTilePositions = { 63 };

        private static GameBoard _gameBoard;
        public static GameBoard GetGameBoard()
        {
            if (_gameBoard == null)
            {
                _gameBoard = new GameBoard();
            }
            return _gameBoard;
        }

        TileFactory factory = new();
        private void FillTileList()
        {
            for (int i = 0; i < _amountOfTiles; i++)
            {
                if (GooseTilePositions.Contains(i))
                {
                    listOfTiles.Add(factory.CreateTile(TileType.Goose));
                }
                else if (PrisonTilePositions.Contains(i))
                {
                    listOfTiles.Add(factory.CreateTile(TileType.Prison));
                }
                else if (BridgeTilePositions.Contains(i))
                {
                    listOfTiles.Add(factory.CreateTile(TileType.Prison));
                }
                else if (InnTilePositions.Contains(i))
                {
                    listOfTiles.Add(factory.CreateTile(TileType.Inn));
                }
                else if (WellTilePositions.Contains(i))
                {
                    listOfTiles.Add(factory.CreateTile(TileType.Well));
                }
                else if (MazeTilePositions.Contains(i))
                {
                    listOfTiles.Add(factory.CreateTile(TileType.Maze));
                }
                else if (DeathTilePositions.Contains(i))
                {
                    listOfTiles.Add(factory.CreateTile(TileType.Death));
                }
                else if (EndTilePositions.Contains(i))
                {
                    listOfTiles.Add(factory.CreateTile(TileType.End));
                }
                else listOfTiles.Add(factory.CreateTile(TileType.Empty));

            }

        }
    }
}
