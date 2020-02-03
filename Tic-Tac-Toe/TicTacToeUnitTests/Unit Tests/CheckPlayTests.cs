using NUnit.Framework;
using TicTacToe.Models;
using TicTacToe.Logic.Interfaces;
using TicTacToe.Logic.Services;
using TicTacToe.Logic;
using System;
namespace TicTacToe.Unit_Tests
{
    [TestFixture]
    public class CheckPlayTests
    {
        ICheckPlay _checkPlay;
        Board emptyBoard;
        Board fullBoard;
        Random _random;

        [SetUp]
        public void Init()
        {
            _checkPlay = new CheckPlay();
            emptyBoard = new Board();
            fullBoard = new Board();
            _random = new Random();
            FillBoard(fullBoard);
        }

        private void FillBoard(Board board)
        {
            Player[] players = new Player[2] { 
                new Player(Constants.PlayerChar1, true, false), 
                new Player(Constants.PlayerChar2, false, true) };

            for (int x = 0; x < board.Size; x++)
            {
                for(int y = 0; y < board.Size; y++)
                {
                    board.PlaceItem(players[_random.Next(0, 1)].Side, new GridPos(x, y));
                }
            }
        }

        [Test]
        public void CheckAvailableTrue()
        {
            GridPos gridPos = new GridPos(0, 0);

            var val = _checkPlay.CheckAvailable(emptyBoard, gridPos);

            Assert.AreEqual(true, val);
        }

        [Test]
        public void CheckAvailableFalse()
        {
            GridPos gridPos = new GridPos(0, 0);

            var val = _checkPlay.CheckAvailable(fullBoard, gridPos);

            Assert.AreEqual(false, val);
        }

        [Test]
        public void GetAvailableAllOpen()
        {
            int expected = emptyBoard.Size * emptyBoard.Size;

            var available = _checkPlay.GetAvailable(emptyBoard);

            Assert.AreEqual(expected, available.Length);

        }

        [Test]
        public void GetAvailableAllTaken()
        {
            var available = _checkPlay.GetAvailable(fullBoard);

            Assert.AreEqual(0, available.Length);
        }

    }
}
