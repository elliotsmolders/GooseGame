using GooseGame.Business;
using GooseGame.Business.Tiles;

namespace GooseGame.Tests
{
    public class PlayerTest
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
        public void WhenPlayerTurnIsOver_ThenNextPlayerIsNewCurrentPlayer()
        {
            //arrange
            GameEngine engine = new GameEngine();
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            engine.Players.Add(player1);
            engine.Players.Add(player2);
            engine.CurrentPlayer = player1;
            //act
            engine.SetNextPlayer();
            //assert
            Assert.That(player2, Is.EqualTo(engine.CurrentPlayer));
        }

        [Test]
        public void WhenPlayerTurnIsOverAndIsLastInList_ThenFirstPlayerInListIsNewCurrentPlayer()
        {
            //arrange
            GameEngine engine = new GameEngine();
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            engine.Players.Add(player1);
            engine.Players.Add(player2);
            engine.CurrentPlayer = engine.Players.Last();
            //act
            engine.SetNextPlayer();
            //assert
            Assert.That(engine.Players.First(), Is.EqualTo(engine.CurrentPlayer));
        }
    }
}