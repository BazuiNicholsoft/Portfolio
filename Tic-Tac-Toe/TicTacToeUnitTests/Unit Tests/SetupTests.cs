using NUnit.Framework;
using TicTacToe.Models;
using TicTacToe.Logic.Interfaces;
using TicTacToe.Logic.Services;
using TicTacToe.Logic;
using System;
using System.Collections.Generic;

namespace TicTacToeUnitTests.Unit_Tests
{
    [TestFixture]
    public class SetupTests
    {
        ISetup _setup;

        Player player1Human = new Player(Constants.PlayerChar1, true, false);
        Player player2Human = new Player(Constants.PlayerChar2, false, false);
        Player player1AI = new Player(Constants.PlayerChar1, true, true);
        Player player2AI = new Player(Constants.PlayerChar2, false, true);

        [SetUp]
        public void init()
        {
            _setup = new Setup();
        }
        [Test]
        public void SetupboardNoParameters()
        {
            Board newBoard = _setup.SetupBoard();

            Assert.AreEqual(3, newBoard.Size);
            Assert.AreEqual(9, newBoard.Grid.Length);
        }

        [Test]
        public void SetupBoardEnteredSize([Range(3, 20, 1)] int size)
        {
            int expected = size * size;

            Board newBoard = _setup.SetupBoard(size);

            Assert.AreEqual(size, newBoard.Size);
            Assert.AreEqual(expected, newBoard.Grid.Length);
        }

        [Test]
        public void SetupPlayersTwoHumanP1First()
        {
            List<Player> expectedPlayers = new List<Player>
            {
                player1Human,
                player2Human
            };

            var players = _setup.SetupPlayers(false, false);

            Assert.AreEqual(expectedPlayers, players);
        }

        [Test]
        public void SetupPlayersTwoAIP1First()
        {
            List<Player> expectedPlayers = new List<Player>
            {
                player1AI,
                player2AI
            };

            var players = _setup.SetupPlayers(true, true);

            Assert.AreEqual(expectedPlayers, players);
        }

        [Test]
        public void SetupPlayersOneHumanOneAIP1First()
        {
            List<Player> expectedPlayers = new List<Player>
            {
                player1Human,
                player2AI
            };

            var players = _setup.SetupPlayers(false, true);

            Assert.AreEqual(expectedPlayers, players);
        }
    }
}
