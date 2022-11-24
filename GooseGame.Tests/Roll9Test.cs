using GooseGame.Business;

namespace GooseGame.Tests
{
    public class Roll9Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(4, 5)]
        [TestCase(5, 4)]
        public void WhenPlayerLandsOnPrisonTileAndAfterRolls5And4_ThenPlayerGoesTo53(int roll1, int roll2)
        {
            //arrange
            GameEngine engine = new GameEngine();
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.CurrentPosition = 56;
            engine.CurrentPlayer = player;
            //act
            player.MovePlayer(2);
            engine.PlayTurn(roll1, roll2);
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(53));
        }

        [Test]
        [TestCase(6, 3)]
        [TestCase(3, 6)]
        public void WhenPlayerLandsOnPrisonTileAndAfterRolls6And3_ThenPlayerGoesTo26(int roll1, int roll2)
        {
            //arrange
            GameEngine engine = new GameEngine();
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.CurrentPosition = 56;
            engine.CurrentPlayer = player;
            //act
            player.MovePlayer(2);
            engine.PlayTurn(roll1, roll2);
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(26));
        }

        [Test]
        [TestCase(4, 5)]
        [TestCase(5, 4)]
        public void WhenPlayerThrows5and4WhileOnPosition0_ThenPlayerMovesToPosition53(int roll1, int roll2)
        {
            //arrange
            GameEngine engine = new GameEngine();
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.CurrentPosition = 0;
            engine.CurrentPlayer = player;
            //act
            engine.PlayTurn(roll1, roll2);
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(53));
        }

        [Test]
        [TestCase(6, 3)]
        [TestCase(3, 6)]
        public void WhenPlayerThrows6and3WhileOnPosition0_ThenPlayerMovesToPosition26(int roll1, int roll2)
        {
            //arrange
            GameEngine engine = new GameEngine();
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.CurrentPosition = 0;
            engine.CurrentPlayer = player;
            //act
            engine.PlayTurn(roll1, roll2);
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(26));
        }
    }
}