using GooseGame.Business;
using GooseGame.Business.Tiles;

namespace GooseGame.Tests

{
    public class MovePlayerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(5,61)]
        [TestCase(9, 57)]
        public void WhenPlayerRollCausesItToGoAboveMaxTileAmount_ThenCountUpToMaxTileAmountAndMoveBackRemainder(int roll, int result)
        {
            //arrange
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.SetPlayerPosition(60);
            //act
            player.MovePlayer(roll);
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(result));

        }
        [Test]

        public void WhenPlayerRollCausesItToGoAboveMaxTileAmountAndThenLandsOnGooseTile_ThenMoveBackwardsForCurrentRoll()
        {
            //arrange
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.SetPlayerPosition(61);
            //act
            player.MovePlayer(6);
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(53));

        }

        [Test]
        //rewrite these type of tests in case special tiles are on other positions? 
        public void WhenPlayerHitsABridgeTile_ThenPlayerMovesToTile12()
        {
            //arrange
            Player player = new Player("TestJos");
            player.SetPlayerPosition(0);
            //act
            player.MovePlayer(6);
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(12));
        }
        [Test]
        public void WhenPlayerHitsAMazeTile_ThenPlayerMovesToTile39()
        {
            //arrange
            Player player = new Player("TestJos");
            player.SetPlayerPosition(40);
            //act
            player.MovePlayer(2);
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(39));
        }

        [Test]
        public void WhenPlayerHitsADeathTile_ThenPlayerMovesToTile0()
        {
            //arrange
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.SetPlayerPosition(56);
            //act
            player.MovePlayer(2);
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(0));
        }

        [Test]
        public void WhenPlayerHitsAGooseTile_ThenPlayerMovesTheSameAmountOfEyes()
        {
            //arrange
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.SetPlayerPosition(7);

            //act
            player.MovePlayer(2);

            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(11));
        }

        [Test]
        public void WhenPlayerHitsAGooseTile_AndHitsAnotherGooseTile_ThenPlayerPlayerKeepsMovingUntilANonGooseTileIsHit()
        {
            //arrange

            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.SetPlayerPosition(4);

            //act
            player.MovePlayer(5);

            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(19));
            Assert.That(player.CurrentTile, Is.InstanceOf(typeof(InnTile)));
        }
    }
}