using GooseGame.Business;

namespace GooseGame.Tests
{
    public class WellTileTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenPlayerLandsOnWell_ThenPlayerIsInWellIsTrue()
        {
            //arrange
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.CurrentPosition = 29;
            //act
            player.MovePlayer(2);
            //Assert
            Assert.That(player.IsInWell, Is.EqualTo(true));
            //Assert.That(board.Tiles[30].playerInWell, Is.EqualTo(player)); kan niet aan de welltile want board.Tiles is een ilist van itiles, itiles hebben geen prop 'playerinwell'
        }

        [Test]
        public void WhenPlayerIsInWell_ThenPlayerWillNotMoveDuringTurn()
        {
            //arrange
            GameEngine engine = new GameEngine();
            Player player1 = new Player("TestJos");
            Player player2 = new Player("player2");
            engine.Players.Add(player1);
            engine.Players.Add(player2);
            engine.CurrentPlayer = player1;
            player1.CurrentPosition = 29;
            player1.MovePlayer(2);

            //act
            engine.PlayTurn(2, 3);
            //Assert
            Assert.That(player1.IsInWell, Is.EqualTo(true));
            Assert.That(player1.CurrentPosition, Is.EqualTo(31));
        }

        [Test]
        public void WhenPlayer1IsInWellAndPlayer2LandsOnWell_ThenPlayer1WillMoveDuringTurn()
        {
            //arrange
            GameEngine engine = new GameEngine();
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            engine.Players.Add(player1);
            engine.Players.Add(player2);
            player1.CurrentPosition = 29;
            player1.MovePlayer(2);
            player2.CurrentPosition = 29;
            engine.CurrentPlayer = player2;

            //act
            engine.PlayTurn(1, 1); //player 2 moves 2 tiles
            engine.CurrentPlayer = player1;
            engine.PlayTurn(1, 1);
            //Assert
            Assert.That(player1.IsInWell, Is.EqualTo(false));
            Assert.That(player2.IsInWell, Is.EqualTo(true));
            Assert.That(player1.CurrentPosition, Is.EqualTo(33));
            Assert.That(player2.CurrentPosition, Is.EqualTo(31));
        }

        [Test]
        public void WhenPlayer1IsInWellAndPlayer2LandsOnWell_ThenPlayer2WillNotMoveDuringTurn()
        {
            //arrange
            GameEngine engine = new GameEngine();
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            engine.Players.Add(player1);
            engine.Players.Add(player2);
            player1.CurrentPosition = 29;
            player1.MovePlayer(2);
            player2.CurrentPosition = 29;
            engine.CurrentPlayer = player2;

            //act
            engine.PlayTurn(1, 1); //player 2 moves 2 tiles
            engine.CurrentPlayer = player2;
            engine.PlayTurn(1, 1); //player 2 moves 2 tiles again
            //Assert
            Assert.That(player1.IsInWell, Is.EqualTo(false));
            Assert.That(player2.IsInWell, Is.EqualTo(true));
            Assert.That(player2.CurrentPosition, Is.EqualTo(31));
        }
    }
}