using GooseGame.Business;
using GooseGame.Business.Interfaces;
using GooseGame.Business.Tiles;

namespace GooseGame.Tests

{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void WhenPlayerIsCreated_ThenInItialTileisStartTileAndPositionIs0()
        {
            //arrange
            GameBoard board = GameBoard.GetGameBoard();
            //act
            Player player = new Player("TestJos");
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(0));
            Assert.That(player.CurrentTile, Is.InstanceOf(typeof(StartTile)));

        }
        [Test]
        [TestCase(4, 5)]
        [TestCase(5, 4)]

        public void WhenPlayerThrows5and4WhileOnStartTile_ThenPlayerMovesToPosition26(int roll1, int roll2)
        {
            //arrange
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            //act

            //assert
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