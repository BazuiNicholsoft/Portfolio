using System;

namespace TicTacToe.Models
{
    public class Board
    {
        public char[,] Grid { get; }
        public int Size { get; }

        public Board()
        {
            Grid = new char[3, 3];
            Size = 3;
        }

        public Board(int size)
        {
            if (size >= 3)
            {
                Grid = new char[size, size];
                Size = size;
            }
            else
                throw new Exception("Board size must be Equal to or greater than 3.");
        }

        public Board(char[,] newGrid)
        {
            if (newGrid != null)
            {
                Grid = newGrid;
                Size = (int)Math.Sqrt(newGrid.Length);
            }
            else
                throw new Exception("Cannot create a Board with a null grid.");
        }
        
        public void PlaceItem(char player, GridPos position)
        {
            Grid[position.x, position.y] = player;
        }

    }
}
