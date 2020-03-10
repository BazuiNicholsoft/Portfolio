using System;
using System.Collections.Generic;
using TicTacToe.Logic.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Logic.Services.AI
{
    public class AILogic: IAILogic
    {
        private readonly ICheckPlay _checkPlay;
        private readonly Random random;

        public AILogic(ICheckPlay checkPlay)
        {
            _checkPlay = checkPlay;
            random = new Random();
        }

        public GridPos BlockingMove(Board board, Player playerToBlock)
        {
            var available = _checkPlay.GetAvailable(board);

            List<GridPos> blocks = new List<GridPos>();

            foreach (var move in available)
            {
                if (_checkPlay.CheckWin(board, playerToBlock.Side, move))
                    blocks.Add(move);
            }

            if(blocks.Count > 0)
            {
                return RandomMove(blocks);
            }
            //Nothing to block
            return new GridPos(-1, -1);
        }

        public GridPos CenterMove(Board board)
        {
            GridPos center;
            if(board.Size % 2 == 0)
            {
                throw new NotImplementedException();
            }
            else
            {
                double half = board.Size / 2;
                int iCenter = (int) Math.Ceiling(half);
                center = new GridPos(iCenter,iCenter);
                if (!_checkPlay.CheckAvailable(board, center))
                    return new GridPos(-1, -1);
            }

            return center;
        }

        public GridPos CornerMove(Board board)
        {
            GridPos[] available = new GridPos[4];
            GridPos topLeft = new GridPos(0, 0);
            GridPos topRight = new GridPos(0, board.Size - 1);
            GridPos bottomLeft = new GridPos(board.Size - 1, 0);
            GridPos bottomRight = new GridPos(board.Size - 1, board.Size - 1);
            if(_checkPlay.CheckAvailable(board, topLeft))
                available[0] = topLeft;
            if (_checkPlay.CheckAvailable(board, topRight))
                available[1] = topRight;
            if (_checkPlay.CheckAvailable(board, bottomLeft))
                available[2] = bottomLeft;
            if (_checkPlay.CheckAvailable(board, bottomRight))
                available[3] = bottomRight;

            return RandomMove(available);

        }

        public GridPos RandomMove(Board board)
        {
            //Go anywhere available
            GridPos[] available = _checkPlay.GetAvailable(board);
            return RandomMove(available);
        }

        public GridPos RandomMove(List<GridPos> available)
        {
            return RandomMove(available.ToArray());
        }

        public GridPos RandomMove(GridPos[] available)
        {
            if (available.Length == 0)
                return new GridPos(-1, -1);
            //Go anywhere available
            int choice = random.Next(0, available.Length - 1);
            return available[choice];
        }

        public GridPos WinningMove(Board board, Player bot)
        {
            GridPos[] available = _checkPlay.GetAvailable(board);

            for (int i = 0; i < available.Length; i++)
            {
                if (_checkPlay.CheckWin(board, bot.Side, available[i]))
                {
                    // return when a winning move is found
                    return available[i];
                }
            }

            //no winning move
            return new GridPos(-1,-1);
        }
    }
}
