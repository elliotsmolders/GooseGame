using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business;

namespace GooseGame.Tests
{
    public class NumberOfRollsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenPlayerPlaysTurn_ThenNumberOfRollsIncreases()
        {
            //arrange
            GameEngine engine = new GameEngine();
            Player player = new Player("TestJos");
            engine.CurrentPlayer = player;
            player.NumberOfRolls = 0;
            //act
            engine.PlayTurn(1, 1);
            //Assert
            Assert.That(player.NumberOfRolls, Is.EqualTo(1));

        }
        [Test]
        public void WhenPlayerPlaysTurn_ThenTotalNumberOfRollsIncreases()
        {
            //arrange
            GameEngine engine = new GameEngine();
            Player player = new Player("TestJos");
            engine.CurrentPlayer = player;
            engine.TotalNumberOfRolls = 0;
            //act
            engine.PlayTurn(1, 1);
            //Assert
            Assert.That(engine.TotalNumberOfRolls, Is.EqualTo(1));

        }

        [Test]
        public void WhenPlayerSkipsTurn_ThenNumberOfRollsDoesntIncrease()
        {
            //arrange
            GameEngine engine = new GameEngine();
            Player player = new Player("TestJos");
            engine.CurrentPlayer = player;
            player.Skips = 1;
            player.NumberOfRolls = 0;
            //act
            engine.PlayTurn(1, 1);
            //Assert
            Assert.That(player.NumberOfRolls, Is.EqualTo(0));

        }
        [Test]
        public void WhenPlayerSkipsTurn_ThenTotalNumberOfRollsDoesntIncrease()
        {
            //arrange
            GameEngine engine = new GameEngine();
            Player player = new Player("TestJos");
            engine.CurrentPlayer = player;
            player.Skips = 1;
            engine.TotalNumberOfRolls = 0;
            //act
            engine.PlayTurn(1, 1);
            //Assert
            Assert.That(engine.TotalNumberOfRolls, Is.EqualTo(0));

        }
        public void WhenPlayerIsInWell_ThenNumberOfRollsAndEngineTotalRollsDoesntIncrease()
        {
            //arrange
            GameEngine engine = new GameEngine();
            Player player = new Player("TestJos");
            engine.CurrentPlayer = player;
            player.IsInWell = true;
            player.NumberOfRolls = 0;
            engine.TotalNumberOfRolls = 0;
            //act
            engine.PlayTurn(1, 1);
            //Assert
            Assert.That(player.NumberOfRolls, Is.EqualTo(0));
            Assert.That(engine.TotalNumberOfRolls, Is.EqualTo(0));

        }
        [Test]
        public void WhenPlayerSkipsTurn_ThenEngineTotalNumberOfRollsDoesntIncrease()
        {
            //arrange
            GameEngine engine = new GameEngine();
            Player player = new Player("TestJos");
            engine.CurrentPlayer = player;
            player.Skips = 1;
            engine.TotalNumberOfRolls = 0;
            //act
            engine.PlayTurn(1, 1);
            //Assert
            Assert.That(engine.TotalNumberOfRolls, Is.EqualTo(0));
        }
        [Test]
        public void WhenPlayerHitsAGooseTile_ThenItDoesntFurtherIncreaseAmountOfRolls()
        {
            //arrange
            GameEngine engine = new GameEngine();
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            engine.CurrentPlayer = player;
            player.SetPlayerPosition(7);
            player.NumberOfRolls = 0;
            //act
            engine.PlayTurn(1, 1);
            //assert
            Assert.That(player.NumberOfRolls, Is.EqualTo(1));
        }
        [Test]
        public void WhenFirstRoll_AmountOfRollsUpdateProperly()
        {
            //arrange
            GameBoard board = GameBoard.GetGameBoard();
            Player player = new Player("TestJos");
            GameEngine engine = new GameEngine();
            engine.CurrentPlayer = player;
            //act
            engine.PlayTurn(3, 3);
            //assert
            Assert.That(player.NumberOfRolls, Is.EqualTo(1));
            Assert.That(engine.TotalNumberOfRolls, Is.EqualTo(1));
        }

    }
}
