using GooseGame.Business;
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
            Player player = new("TestJos");
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(0));
            Assert.That(player.CurrentTile, Is.InstanceOf(typeof(StartTile)));
        }

        [Test]
        [TestCase(4, 5)]
        [TestCase(5, 4)]
        public void WhenPlayerThrows5and4WhileOnPosition0_ThenPlayerMovesToPosition53(int roll1, int roll2)
        {
            //arrange
            GameEngine engine = new();
            GameEngine.Roll1 = roll1;
            GameEngine.Roll2 = roll2;

            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.CurrentPosition = 0;
            engine.CurrentPlayer = player;
            //act
            engine.PlayTurn();
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(53));
        }

        [Test]
        [TestCase(6, 3)]
        [TestCase(3, 6)]
        public void WhenPlayerThrows6and3WhileOnPosition0_ThenPlayerMovesToPosition26(int roll1, int roll2)
        {
            //arrange
            GameEngine engine = new();
            GameEngine.Roll1 = roll1;
            GameEngine.Roll2 = roll2;

            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            player.CurrentPosition = 0;
            engine.CurrentPlayer = player;
            //act
            engine.PlayTurn();
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(26));
        }

        [Test]
        [TestCase(5, 61)]
        [TestCase(9, 57)]
        public void WhenPlayerRollCausesItToGoAboveMaxTileAmount_ThenCountUpToMaxTileAmountAndMoveBackRemainder(int roll, int result)
        {
            //arrange
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new("TestJos");
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
            Player player = new("TestJos");
            player.SetPlayerPosition(61);
            //act
            player.MovePlayer(6);
            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(53));
        }

        [Test]
        public void WhenPlayerPlaysTurn_ThenNumberOfRollsIncreases()
        {
            //arrange
            GameEngine engine = new();
            GameEngine.Roll1 = 1;
            GameEngine.Roll2 = 1;

            Player player = new("TestJos");
            engine.CurrentPlayer = player;
            player.NumberOfRolls = 0;
            //act
            engine.PlayTurn();
            //Assert
            Assert.That(1, Is.EqualTo(player.NumberOfRolls));
        }

        [Test]
        public void WhenPlayerPlaysTurn_ThenTotalNumberOfRollsIncreases()
        {
            //arrange
            GameEngine engine = new();
            GameEngine.Roll1 = 1;
            GameEngine.Roll2 = 1;

            Player player = new("TestJos");
            engine.CurrentPlayer = player;
            engine.TotalNumberOfRolls = 0;
            //act
            engine.PlayTurn();
            //Assert
            Assert.That(1, Is.EqualTo(engine.TotalNumberOfRolls));
        }

        [Test]
        public void WhenPlayerSkipsTurn_ThenNumberOfRollsDoesntIncrease()
        {
            //arrange
            GameEngine engine = new();
            GameEngine.Roll1 = 1;
            GameEngine.Roll2 = 1;

            Player player = new("TestJos");
            engine.CurrentPlayer = player;
            player.TurnsToSkip = 1;
            player.NumberOfRolls = 0;
            //act
            engine.PlayTurn();
            //Assert
            Assert.That(0, Is.EqualTo(player.NumberOfRolls));
        }

        [Test]
        public void WhenPlayerSkipsTurn_ThenTotalNumberOfRollsDoesntIncrease()
        {
            //arrange
            GameEngine engine = new();
            GameEngine.Roll1 = 1;
            GameEngine.Roll2 = 1;

            Player player = new("TestJos");
            engine.CurrentPlayer = player;
            player.TurnsToSkip = 1;
            engine.TotalNumberOfRolls = 0;
            //act
            engine.PlayTurn();
            //Assert
            Assert.That(0, Is.EqualTo(engine.TotalNumberOfRolls));
        }

        public void WhenPlayerIsInWell_ThenNumberOfRollsAndEngineTotalRollsDoesntIncrease()
        {
            //arrange
            GameEngine engine = new();
            GameEngine.Roll1 = 1;
            GameEngine.Roll2 = 1;

            Player player = new("TestJos");
            engine.CurrentPlayer = player;
            player.IsInWell = true;
            player.NumberOfRolls = 0;
            engine.TotalNumberOfRolls = 0;
            //act
            engine.PlayTurn();
            //Assert
            Assert.That(0, Is.EqualTo(player.NumberOfRolls));
            Assert.That(0, Is.EqualTo(engine.TotalNumberOfRolls));
        }

        [Test]
        public void WhenPlayerSkipsTurn_ThenEngineTotalNumberOfRollsDoesntIncrease()
        {
            //arrange
            GameEngine engine = new();
            GameEngine.Roll1 = 1;
            GameEngine.Roll2 = 1;

            Player player = new("TestJos");
            engine.CurrentPlayer = player;
            player.TurnsToSkip = 1;
            engine.TotalNumberOfRolls = 0;
            //act
            engine.PlayTurn();
            //Assert
            Assert.That(0, Is.EqualTo(engine.TotalNumberOfRolls));
        }

        [Test]
        public void WhenPlayerHitsAGooseTile_ThenItDoesntFurtherIncreaseAmountOfRolls()
        {
            //arrange
            GameEngine engine = new();
            GameEngine.Roll1 = 1;
            GameEngine.Roll2 = 1;

            GameBoard board = GameBoard.GetGameBoard();
            Player player = new("TestJos");
            engine.CurrentPlayer = player;
            player.SetPlayerPosition(7);
            player.NumberOfRolls = 0;
            //act
            engine.PlayTurn();
            //assert
            Assert.That(player.NumberOfRolls, Is.EqualTo(1));
        }

        [Test]
        public void WhenPlayerHitsABridgeTile_ThenPlayerMovesToTile12()
        {
            //arrange
            Player player = new("TestJos");
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
            Player player = new("TestJos");
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
            Player player = new("TestJos");
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
            Player player = new("TestJos");
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
            Player player = new("TestJos");
            player.SetPlayerPosition(4);

            //act
            player.MovePlayer(5);

            //assert
            Assert.That(player.CurrentPosition, Is.EqualTo(19));
            Assert.That(player.CurrentTile, Is.InstanceOf(typeof(InnTile)));
        }
    }
}