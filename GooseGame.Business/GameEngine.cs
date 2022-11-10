using GooseGame.Business.Factory;
using GooseGame.Business.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business
{
    public class GameEngine
    {
        public int AmountOfPlayers { get; set; }
        public int AmountOfTiles { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Player> ListOfPlayers { get; set; } = new List<Player>();
        public int AmountOfThrows { get; set; }
        public GameBoard Board { get; set; }

        public void Init()
        {
            CreateBoard();
            CreatePlayer(AmountOfPlayers);
            PlacePlayers();
        }

        public void Run()
        {
            TileFactory factory = new TileFactory();
            foreach (ITile tile in Board.listOfTiles)
            {
                tile.HandlePlayer();
            }
        }

        private void PlacePlayers()
        {
            throw new NotImplementedException();
        }

        private void CreatePlayer(int amountOfPlayers)
        {
            throw new NotImplementedException();
        }

        private void CreateBoard()
        {
            GameBoard _board = GameBoard.GetGameBoard();
        }

        public void Restore()
        {
            throw new NotImplementedException();
        }
    }
}