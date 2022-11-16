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