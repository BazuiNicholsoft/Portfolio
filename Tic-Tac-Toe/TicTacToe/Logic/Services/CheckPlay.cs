using TicTacToe.Models;
using TicTacToe.Logic.Interfaces;
using System.Collections.Generic;

namespace TicTacToe.Logic.Services
{
    public class CheckPlay : ICheckPlay
    {
        //Make sure the chosen play is available
        public bool CheckAvailable(Board grid, GridPos pos)
        {
            if (!char.IsLetterOrDigit(grid.Grid[pos.x, pos.y]))
                return true;
            return false;
        }

        //Did someone win?
        public bool CheckWin(Board grid, char player, GridPos lastPlay)
        {
            if (CheckHorizontalWin(grid, player, lastPlay) || CheckVerticalWin(grid, player, lastPlay) || CheckDiagonalWin(grid, player, lastPlay))
                return true;
            return false;
        }

        //Return a list of all legal and available positions. (Used for AI logic)
        public GridPos[] GetAvailable(Board grid)
        {
            List<GridPos> available = new List<GridPos>();
            for(int x = 0; x < grid.Size; x++)
            {
                for(int y = 0; y < grid.Size; y++)
                {
                    GridPos newGridPos = new GridPos(x, y);
                    if(CheckAvailable(grid, newGridPos)){
                        available.Add(newGridPos);
                    }
                }
            }

            return available.ToArray();
        }

        //Check to see if the player won horizontally
        private bool CheckHorizontalWin(Board grid, char player, GridPos lastPlay)
        {
            //if everything in the row belongs to the current player they won
            int x = lastPlay.x; // the row we are checking
            for(int i = 0; i < grid.Size; i++)
            {
                if (lastPlay.y != i && grid.Grid[x, i] != player)
                    return false;
            }
            return true;

        }
        //Check to see if the player won vertically
        private bool CheckVerticalWin(Board grid, char player, GridPos lastPlay)
        {
            //if everything in the column belongs to the current player they won
            int y = lastPlay.y; // the column we are checking
            for (int i = 0; i < grid.Size; i++)
            {
                if (lastPlay.x != i && grid.Grid[i, y] != player)
                    return false;
            }
            return true;
        }

        //Check to see if the player won Diagonally
        private bool CheckDiagonalWin(Board grid, char player, GridPos lastPlay)
        {
            //Check if the lastPlay was a diagonal spot
            if (!CheckDiagonal(grid, lastPlay))
                return false;
            //if everything in the one of the two diagonals belongs to the current player they won
            if (lastPlay.x == lastPlay.y)
            {
                for(int i = 0; i < grid.Size; i++)
                {
                    if (lastPlay.x != i && grid.Grid[i, i] != player)
                        return false;
                }
            }
            else if(lastPlay.x + lastPlay.y == grid.Size - 1)
            {
                int y = grid.Size-1;
                for(int x = 0; x < grid.Size; x++)
                {
                    if ((lastPlay.x != x && lastPlay.y !=y) && grid.Grid[x, y] != player)
                        return false;
                    y--;
                }
            }                
            return true;
        }

        //See if the lastPlay was part of a possible diagonal win
        //if x and y are equal it is a diagonal
        //if x and y added together equal the size of the grid, it is a diagonal
        private bool CheckDiagonal(Board grid, GridPos lastPlay)
        {
            if ((lastPlay.x == lastPlay.y) || (lastPlay.x + lastPlay.y == grid.Size - 1))
                return true;
            return false;
        }
    }
}
