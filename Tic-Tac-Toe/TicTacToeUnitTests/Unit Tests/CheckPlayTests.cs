using NUnit.Framework;
using TicTacToe.Models;
using TicTacToe.Logic.Interfaces;
using TicTacToe.Logic.Services;
using TicTacToe.Logic;
using System;

namespace TicTacToeUnitTests.Unit_Tests
{
    [TestFixture]
    public class CheckPlayTests
    {
        ICheckPlay _checkPlay;
        Board emptyBoard;
        Board fullBoard;
        Board Player1Board;
        Random _random;
        Player[] players;

        [SetUp]
        public void Init()
        {
            //setup our class to be used
            _checkPlay = new CheckPlay();

            //setup test boards
            emptyBoard = new Board();
            fullBoard = new Board();
            Player1Board = new Board();

            //Random some things
            _random = new Random();

            //Player Setups
            players = new Player[2] {
                new Player(Constants.PlayerChar1, true, false),
                new Player(Constants.PlayerChar2, false, true) };
            
            Player[] onePlayer = new Player[1] { players[0] };

            //Fill some boards
            FillBoard(fullBoard, players);
            FillBoard(Player1Board, onePlayer);
        }

        private void FillBoard(Board board, Player[] players)
        {
            for (int x = 0; x < board.Size; x++)
            {
                for(int y = 0; y < board.Size; y++)
                {
                    UpdateBoard(board, new GridPos(x, y), players[_random.Next(0, players.Length - 1)]);
                }
            }
        }
        private void UpdateBoard(Board board, GridPos gridPos, Player player)
        {
            board.PlaceItem(player.Side, gridPos);
        }

        [Test]
        public void CheckAvailableTrue()
        {
            GridPos gridPos = new GridPos(0, 0);

            var val = _checkPlay.CheckAvailable(emptyBoard, gridPos);

            Assert.IsTrue(val);
        }

        [Test]
        public void CheckAvailableFalse()
        {
            GridPos gridPos = new GridPos(0, 0);

            var val = _checkPlay.CheckAvailable(fullBoard, gridPos);

            Assert.IsFalse(val);
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

        [Test]
        public void CheckWinHorizontalFalse()
        {
            for (int x = 0; x < emptyBoard.Size; x++)
            {
                var win = _checkPlay.CheckWin(emptyBoard, players[0].Side, new GridPos(x, 0));
                Assert.IsFalse(win);
            }
        }

        [Test]
        public void CheckWinVerticalFalse()
        {
            for (int y = 0; y < emptyBoard.Size; y++)
            {
                var win = _checkPlay.CheckWin(emptyBoard, players[0].Side, new GridPos(0, y));
                Assert.IsFalse(win);
            }
        }

        [Test]
        public void CheckWinDiagonalFalse()
        {
            var win1 = _checkPlay.CheckWin(emptyBoard, players[0].Side, new GridPos(0, emptyBoard.Size - 1));
            var win2 = _checkPlay.CheckWin(emptyBoard, players[0].Side, new GridPos(emptyBoard.Size - 1, emptyBoard.Size - 1));
            Assert.IsFalse(win1);
            Assert.IsFalse(win2);
            
        }

        [Test]
        public void CheckWinHorizontalTrue()
        {
            for(int x = 0; x < Player1Board.Size; x++)
            {
                var win = _checkPlay.CheckWin(Player1Board, players[0].Side, new GridPos(x, 0));
                Assert.IsTrue(win);
            }
        }

        [Test]
        public void CheckWinVerticalTrue()
        {
            for (int y = 0; y < emptyBoard.Size; y++)
            {
                var win = _checkPlay.CheckWin(Player1Board, players[0].Side, new GridPos(0, y));
                Assert.IsTrue(win);
            }
        }

        [Test]
        public void CHeckWinDiagonalTrue()
        {
            var win1 = _checkPlay.CheckWin(Player1Board, players[0].Side, new GridPos(0, Player1Board.Size - 1));
            var win2 = _checkPlay.CheckWin(Player1Board, players[0].Side, new GridPos(Player1Board.Size - 1, Player1Board.Size - 1));
            Assert.IsTrue(win1);
            Assert.IsTrue(win2);
        }

    }
}
