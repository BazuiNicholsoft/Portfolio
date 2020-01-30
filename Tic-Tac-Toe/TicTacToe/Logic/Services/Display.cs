using TicTacToe.Models;
using TicTacToe.Logic.Interfaces;

namespace TicTacToe.Logic.Services
{
    public class Display : IDisplay
    {
        public string DrawGrid(Board grid)
        {
            int x = 0, y;
            string lines = DrawLines(grid);
            string display = lines;
            
            int i = 0;
            while(x < grid.Size)
            {
                y = 0;
                while(y < grid.Size)
                {
                    display += "|";
                    if (char.IsLetterOrDigit(grid.Grid[x, y]))
                        display += grid.Grid[x, y];
                    else
                        display += i;
                    i++;
                    y++;
                }
                display += "| \n" + lines;

                x++;
            }

            return display;
        }

        private string DrawLines(Board grid)
        {
            string display = string.Empty;
            for (int c = 0; c < (grid.Size * 2); c++)
            {
                display += "-";
            }
            display += "\n";
            return display;
        }
    }
}
