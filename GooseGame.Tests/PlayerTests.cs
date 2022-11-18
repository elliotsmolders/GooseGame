using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business;

namespace GooseGame.Tests
{
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
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
